using backend.dtos.request;
using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IObjetivoUsuarioService
{
  Task<ObjetivoUsuarioResponseDto> ElegirObjetivoAsync(int objetivoId, int usuarioId);
  Task<IEnumerable<PendingObjetivoDto>> GetPendingObjetivosByUnidadAsync(int unidadId, int dirigenteId);
  Task<ObjetivoUsuarioResponseDto> ValidarObjetivoAsync(ValidarObjetivoDto dto, int dirigenteId);
  Task DenegarObjetivoAsync(ValidarObjetivoDto dto, int dirigenteId);
}
