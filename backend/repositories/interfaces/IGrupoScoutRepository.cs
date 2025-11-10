using backend.data.models;

namespace backend.repositories.interfaces;

public interface IGrupoScoutRepository
{
  Task<IEnumerable<GrupoScout>> GetAll();
  Task<IEnumerable<GrupoScout>> GetByDistritoIdAsync(int distritoId);
}
