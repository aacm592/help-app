using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IRamaService
{
  Task<IEnumerable<CatalogDto>> GetAllAsync();
}
