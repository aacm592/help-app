using backend.dtos.auth;
using backend.dtos.request;
using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IAuthService
{
  Task<UserResponseDto> RegisterAsync(RegisterDto registerDto);

  Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
  Task ChangePasswordAsync(int userId, ChangePasswordDto dto);
}
