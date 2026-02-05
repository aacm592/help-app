using backend.dtos.registros;
using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IGrupoScoutService
{
  Task<IEnumerable<CatalogDto>> GetAllAsync();
  Task<IEnumerable<CatalogDto>> GetByDistritoIdAsync(int distritoId);
  Task<IEnumerable<UnidadUsersDto>> UsersById(int id);
  Task<IEnumerable<UnidadUsersDto>> GetUsersByRamaId(int id, int ramaId);
}
