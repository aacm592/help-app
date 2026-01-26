using backend.data.models.registros;

namespace backend.repositories.interfaces;

public interface IGestionRepository
{
  public Task<Gestion?> GetGestionActual();
  public Task<Gestion?> CreateGestion(Gestion gestion);
}