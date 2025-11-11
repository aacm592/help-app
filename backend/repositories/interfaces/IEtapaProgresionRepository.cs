using backend.data.models;

namespace backend.repositories.interfaces;

public interface IEtapaProgresionRepository
{
  Task<IEnumerable<EtapaProgresion>> GetByRamaIdAsync(int ramaId);
}
