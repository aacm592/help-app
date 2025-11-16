using backend.data.models;

namespace backend.repositories.interfaces;

public interface IObjetivoUsuarioRepository
{
  Task<ObjetivoUsuario> AddAsync(ObjetivoUsuario objetivoUsuario);
  Task<bool> ExistsAsync(int usuarioId, int objetivoId);
  Task<IEnumerable<ObjetivoUsuario>> GetPendingByScoutIdsAsync(IEnumerable<int> scoutIds);
  Task<ObjetivoUsuario?> GetByUsuarioYObjetivoAsync(int usuarioId, int objetivoId);
  Task UpdateAsync(ObjetivoUsuario objetivoUsuario);
  Task DeleteAsync(ObjetivoUsuario objetivoUsuario);
  Task<ISet<int>> GetUserObjetivoIdsAsync(int usuarioId);
  Task<IEnumerable<ObjetivoUsuario>> GetByUsuarioIdAsync(int usuarioId);
  Task<IEnumerable<ObjetivoUsuario>> GetByUsuarioIdWithFullTreeAsync(int usuarioId);
}
