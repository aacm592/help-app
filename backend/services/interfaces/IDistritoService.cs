using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IDistritoService
{
  Task<IEnumerable<CatalogDto>> GetAllAsync();
}
