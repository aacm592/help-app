using backend.dtos.request;
using backend.dtos.responses;
using backend.dtos.responses.progresion;

namespace backend.services.interfaces;

public interface IObjetivoUsuarioService
{
  Task<ObjetivoUsuarioResponseDto> ElegirObjetivoAsync(int objetivoId, int usuarioId);
  Task<IEnumerable<PendingObjetivoDto>> GetPendingObjetivosByUnidadAsync(int unidadId, int dirigenteId);
  Task<ObjetivoUsuarioResponseDto> ValidarObjetivoAsync(ValidarObjetivoDto dto, int dirigenteId);
  Task DenegarObjetivoAsync(ValidarObjetivoDto dto, int dirigenteId);
  Task<IEnumerable<ObjetivoUsuarioResponseDto>> GetMisObjetivosAsync(int usuarioId);
  Task<IEnumerable<RamaObjetivosDto>> GetScoutObjetivosAgrupadosAsync(int scoutId, int solicitanteId);
  Task<IEnumerable<ObjetivoEtapaResumeDto>> GetResume(int scoutId);
  Task<IEnumerable<ObjetivoEtapaResumeDto>> GetResume(int scoutId, int dirigenteId);
}
