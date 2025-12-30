using backend.dtos.responses.especialidades;

namespace backend.services.interfaces;

public interface IEspecialidadServer
{
  Task<IEnumerable<EspecialidadDto>> GetEspecialidadesByRama(int ramaId, int userId);
}
