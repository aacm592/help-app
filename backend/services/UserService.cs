
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using backend.data.models;
using backend.dtos.auth;
using backend.repositories.interfaces;
using backend.services.interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using backend.dtos.responses;

namespace backend.services;

public class UserService : IUserService
{

  private readonly IUserRepository _userRepository;
  private readonly IConfiguration _configuration;
  private readonly IMapper _mapper;


  public UserService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
  {
    _userRepository = userRepository;
    _configuration = configuration;
    _mapper = mapper;
  }

  public async Task<LoginResponseDto> ChangeUserToDiri(int userId)
  {
    var user = await _userRepository.GetByIdAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado");

    if (user.TipoId == 2)
      throw new ApplicationException("Ya eres dirigente");

    var age = CalculateAge(user.Profile!.FechaNacimiento);

    if (age < 18)
      throw new ApplicationException("Debes tener al menos 18 años de edad para ser dirigente");

    user.TipoId = 2;

    await _userRepository.UpdateAsync(user);

    var userResponse = _mapper.Map<UserResponseDto>(user);
    string token = GenerateJwtToken(user);

    return new LoginResponseDto
    {
      Token = token,
      User = userResponse
    };
  }

  private static int CalculateAge(DateTime dateOfBirth)
  {
    var birthDateUtc = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc);
    var today = DateTime.UtcNow;
    var age = today.Year - birthDateUtc.Year;
    if (birthDateUtc.Date > today.AddYears(-age)) age--;
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

}
