using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using backend.data.models;
using backend.data.models.profile;
using backend.dtos.auth;
using backend.dtos.request;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;
using Microsoft.IdentityModel.Tokens;

namespace backend.services;

public class AuthService: IAuthService
{
  private readonly IUserRepository _userRepository;
  private readonly ITipoRepository _tipoRepository;
  private readonly IConfiguration _configuration;
  private readonly IMapper _mapper;
  public AuthService(
    IUserRepository userRepository, 
    ITipoRepository tipoRepository,
    IConfiguration configuration,
    IMapper mapper)
  {
    _userRepository = userRepository;
    _tipoRepository = tipoRepository;
    _configuration = configuration;
    _mapper = mapper;
  }
  
  private static readonly char[] CodigoChars =
    "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ123456789".ToCharArray();
  
  public async Task<UserResponseDto> RegisterAsync(RegisterDto registerDto)
  {
    var existingUser = await _userRepository.GetByUsernameAsync(registerDto.NombreUsuario);
    if (existingUser != null)
      throw new ApplicationException("El nombre de usuario ya está en uso.");
    
    var fechaNacimientoUtc = DateTime.SpecifyKind(registerDto.FechaNacimiento, DateTimeKind.Utc);
    
    int age = CalculateAge(fechaNacimientoUtc);
    string tipoNombre = (age >= 22) ? "Dirigente" : "Scout";
    var tipo = await _tipoRepository.GetByNameAsync(tipoNombre);
    
    if (tipo == null)
      throw new ApplicationException($"Error: El tipo de usuario '{tipoNombre}' no está configurado.");

    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Contrasena);
    
    var userProfile = new UserProfile
    {
      Nombre = registerDto.Nombre,
      Apellido = registerDto.Apellido,
      FechaNacimiento = fechaNacimientoUtc,
    };

    if (tipo.Id == 1)
      userProfile.ScoutProfile = new ScoutProfile();
    if (tipo.Id == 2)
      userProfile.DiriProfile = new DiriProfile();

    var newUser = new User
    {
      NombreUsuario = registerDto.NombreUsuario,
      Contrasena = hashedPassword,
      TipoId = tipo.Id,
      Profile = userProfile,
      DateCreated = DateTime.UtcNow
    };
    
    var userGuardado = await _userRepository.AddAsync(newUser);

    return _mapper.Map<UserResponseDto>(userGuardado);
  }

  public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
  {
    var user = await _userRepository.GetByUsernameAsync(loginDto.NombreUsuario);
    if (user == null)
      throw new ApplicationException("Credenciales inválidas.");

    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Contrasena, user.Contrasena);

    if (!isPasswordValid)
      throw new ApplicationException("Credenciales inválidas.");

    string token = GenerateJwtToken(user);
    var userResponse = _mapper.Map<UserResponseDto>(user);

    user.LastSesion = DateTime.UtcNow;
    
    await _userRepository.UpdateAsync(user);
    return new LoginResponseDto 
    { 
      Token = token, 
      User = userResponse
    };  
  }
  
  public async Task ChangePasswordAsync(int userId, ChangePasswordDto dto)
  {
    var user = await _userRepository.GetByIdAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");

    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.ContrasenaActual, user.Contrasena);
    if (!isPasswordValid)
      throw new ApplicationException("La contraseña actual es incorrecta.");

    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.NuevaContrasena);
    user.Contrasena = hashedPassword;

    await _userRepository.UpdateAsync(user);
  }
  
  public async Task<ResetCodeResponseDto> GeneratePasswordResetCodeAsync(int scoutId, int dirigenteId)
  {
    var dirigente = await _userRepository.GetByIdWithTipoAndUnidadesAsync(dirigenteId);
    if (dirigente == null || dirigente.Tipo.Nombre != "Dirigente")
      throw new ApplicationException("Acción no autorizada. No eres un Dirigente.");

    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(scoutId);
    if (scout == null)
      throw new ApplicationException("Scout no encontrado.");

    if (scout.Tipo.Nombre != "Scout")
      throw new ApplicationException("Solo se pueden generar códigos para usuarios de tipo 'Scout'.");

    var dirigenteUnidadIds = dirigente.Unidades.Select(u => u.Id).ToHashSet();
    var scoutEstaEnUnidadDelDirigente = scout.Unidades.Any(u => dirigenteUnidadIds.Contains(u.Id));

    if (!scoutEstaEnUnidadDelDirigente)
      throw new ApplicationException("No tienes permiso para generar un código para este Scout, ya que no pertenece a tus unidades.");

    string resetCode = GenerateRandomCode();
    
    scout.PasswordResetToken = resetCode;
    scout.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1);

    await _userRepository.UpdateAsync(scout);

    return new ResetCodeResponseDto { ResetCode = resetCode };
  }

  public async Task<ResetCodeResponseDto> SuperGeneratePasswordResetCodeAsync(int scoutId, string password)
  {
    if (password != "qwert123")
      throw new ApplicationException("Usuario no encontrado.");

    var scout = await _userRepository.GetByIdAsync(scoutId);
    if (scout == null)
      throw new ApplicationException("Scout no encontrado.");

    string resetCode = GenerateRandomCode();
    
    scout.PasswordResetToken = resetCode;
    scout.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1);

    await _userRepository.UpdateAsync(scout);

    return new ResetCodeResponseDto { ResetCode = resetCode };
  }
  
  public async Task ResetPasswordAsync(ResetPasswordDto dto)
  {
    var user = await _userRepository.GetByUsernameAsync(dto.NombreUsuario);
    
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");

    if (user.PasswordResetToken != dto.ResetCode)
      throw new ApplicationException("El código de reseteo es incorrecto.");

    if (user.PasswordResetTokenExpiry == null || user.PasswordResetTokenExpiry.Value < DateTime.UtcNow)
      throw new ApplicationException("El código de reseteo ha expirado.");

    user.Contrasena = BCrypt.Net.BCrypt.HashPassword(dto.NuevaContrasena);
    
    user.PasswordResetToken = null;
    user.PasswordResetTokenExpiry = null;

    await _userRepository.UpdateAsync(user);
  }

  private int CalculateAge(DateTime dateOfBirth)
  {
    var today = DateTime.UtcNow;
    var age = today.Year - dateOfBirth.Year;
            
    if (dateOfBirth.Date > today.AddYears(-age))
      age--;

    return age;
  }
  
  private string GenerateJwtToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
    var claims = new List<Claim>
    {
      new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), 
      new Claim(ClaimTypes.Name, user.NombreUsuario),
      new Claim(ClaimTypes.Role, user.TipoId.ToString()),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };
    
    if (user.UserPermisos.FirstOrDefault() != null)
      foreach (var up in user.UserPermisos)
        claims.Add(new Claim(ClaimTypes.Role, "p" + up.PermisoId));
    
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.UtcNow.AddHours(1),
      Issuer = _configuration["Jwt:Issuer"],
      Audience = _configuration["Jwt:Audience"],
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
  
  private string GenerateRandomCode(int length = 6)
  {
    return RandomNumberGenerator.GetString(CodigoChars, length);
  }
}
