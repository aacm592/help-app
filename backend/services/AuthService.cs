using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using backend.data.models;
using backend.dtos.auth;
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
    var newUser = new User
    {
      Nombre = registerDto.Nombre,
      FechaNacimiento = fechaNacimientoUtc,
      NombreUsuario = registerDto.NombreUsuario,
      Contrasena = hashedPassword,
      TipoId = tipo.Id
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

    return new LoginResponseDto 
    { 
      Token = token, 
      User = userResponse
    };  }

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
}
