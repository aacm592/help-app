using backend.data.models.registros;

namespace backend.services.interfaces;

public interface IRegistroService
{
  public Task RegisterUserToGroup(int scoutId, int diriId);
}
