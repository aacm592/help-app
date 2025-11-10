using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IGrupoScoutService
{
  Task<IEnumerable<CatalogDto>> GetAllAsync();
  Task<IEnumerable<CatalogDto>> GetByDistritoIdAsync(int distritoId);
}
