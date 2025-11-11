using backend.data.models;

namespace backend.repositories.interfaces;

public interface IObjetivoUsuarioRepository
{
  Task<ObjetivoUsuario> AddAsync(ObjetivoUsuario objetivoUsuario);
  Task<bool> ExistsAsync(int usuarioId, int objetivoId);
}
