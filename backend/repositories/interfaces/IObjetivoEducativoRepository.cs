using backend.data.models;

namespace backend.repositories.interfaces;

public interface IObjetivoEducativoRepository
{
  Task<IEnumerable<ObjetivoEducativo>> GetByEtapaIdAsync(int etapaId);
  Task<ObjetivoEducativo?> GetByIdAsync(int id);
  Task<IEnumerable<ObjetivoEducativo>> GetByRamaIdAsync(int ramaId);
}
