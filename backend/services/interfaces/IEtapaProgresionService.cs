using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IEtapaProgresionService
{
  Task<IEnumerable<CatalogDto>> GetByRamaIdAsync(int ramaId);
}
