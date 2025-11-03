using backend.dtos.responses;

namespace backend.dtos.auth;

public class LoginResponseDto
{
  public string Token { get; set; }
  public UserResponseDto User { get; set; }
}