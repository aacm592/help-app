using backend.data.models.registros;
using backend.dtos.auth;

namespace backend.services.interfaces;

public interface IRegistroService
{
  public Task RegisterUserToGroup(IdDto scoutId, int diriId);
  public Task CancelRegisterToGroup(int scoutId, int diriId);
}
