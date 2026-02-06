using backend.data.models;

namespace backend.repositories.interfaces;

public interface IGrupoScoutRepository
{
  Task<IEnumerable<GrupoScout>> GetAll();
  Task<IEnumerable<GrupoScout>> GetByDistritoIdAsync(int distritoId);
  Task<GrupoScout?> GetByIdWithUsers(int id, int gestionId);
  Task<GrupoScout?> GetByRamaWithUsers(int id, int gestionId, int ramaId);
  
  Task<GrupoScout?> GetById(int id);
}
