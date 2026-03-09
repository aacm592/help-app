using backend.dtos.auth;
using backend.dtos.registros;

namespace backend.services.interfaces;

public interface IRegistroService
{
  Task RegisterUserToGroup(IdDto scoutId, int diriId);
  Task CancelRegisterToGroup(int scoutId, int diriId);
  Task SendRegistersToDistrito(IEnumerable<RegistroDto> users, int userId);
}
