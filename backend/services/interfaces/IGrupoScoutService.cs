using backend.dtos.registros;
using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IGrupoScoutService
{
  Task<IEnumerable<CatalogDto>> GetAllAsync();
  Task<IEnumerable<CatalogDto>> GetByDistritoIdAsync(int distritoId);
  Task<IEnumerable<GrupoUnidadesResponseDto>> UsersById(int id);
}
