using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IObjetivoEducativoService
{
  Task<IEnumerable<ObjetivoEducativoDto>> GetByEtapaIdAsync(int etapaId);  
}
