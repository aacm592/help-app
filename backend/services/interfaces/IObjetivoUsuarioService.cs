using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IObjetivoUsuarioService
{
  Task<ObjetivoUsuarioResponseDto> ElegirObjetivoAsync(int objetivoId, int usuarioId);
}
