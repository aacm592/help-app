using backend.dtos.auth;

namespace backend.services.interfaces;

public interface IUserService
{
  Task<LoginResponseDto> ChangeUserToDiri(int UserId);
}