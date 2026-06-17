using backend.dtos.request;
using backend.dtos.responses.especialidades;

namespace backend.services.interfaces;

public interface IEspecialidadServer
{
  Task<IEnumerable<EspecialidadDto>> GetEspecialidadesByRama(int ramaId, int userId);
  Task<IEnumerable<EspecialidadDto>> GetEspecialidadesByRama(int ramaId, int userId, int diriId);
  Task SelectRequerimiento(int requerimientoId, int userId);
  Task ValidarRequerimiento(ValidarObjetivoDto dto, int dirigenteId);
  Task AsignarRequerimiento(ValidarObjetivoDto dto, int dirigenteId);
  Task<IEnumerable<UserRequisitoEspDto>> GetReqByUnidad(int unidadId, int userId);
  Task<IEnumerable<EspecialidadResumeDto>> GetUserResume(int userId);
  Task<IEnumerable<EspecialidadResumeDto>> GetUserResume(int userId, int dirigenteId);
}
