using backend.data.models.registros;

namespace backend.repositories.interfaces;

public interface IGestionRepository
{
  Task<Gestion?> GetGestionActual();
  Task<Gestion?> GetUltimaGestion();
  Task<Gestion?> CreateGestion(Gestion gestion);
}
