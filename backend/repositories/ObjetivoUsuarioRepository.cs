using backend.data;
using backend.data.models;
using backend.enums;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class ObjetivoUsuarioRepository : IObjetivoUsuarioRepository
{
  private readonly ScoutsAppContext _context;

  public ObjetivoUsuarioRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<ObjetivoUsuario> AddAsync(ObjetivoUsuario objetivoUsuario)
  {
    _context.ObjetivosUsuario.Add(objetivoUsuario);
    await _context.SaveChangesAsync();
    return objetivoUsuario;
  }

  public async Task<bool> ExistsAsync(int usuarioId, int objetivoId)
  {
    return await _context.ObjetivosUsuario
      .AnyAsync(ou => ou.UsuarioId == usuarioId && ou.ObjetivoEducativoId == objetivoId);
  }
  
  public async Task<IEnumerable<ObjetivoUsuario>> GetPendingByScoutIdsAsync(IEnumerable<int> scoutIds)
  {
    return await _context.ObjetivosUsuario
      .Include(ou => ou.User) 
      .Include(ou => ou.ObjetivoEducativo)
      .Where(ou => ou.Status == ObjetivoStatus.Pendiente)
      .Where(ou => scoutIds.Contains(ou.UsuarioId))
      .OrderBy(ou => ou.User.Nombre)
      .ToListAsync();
  }
  
  public async Task<ObjetivoUsuario?> GetByUsuarioYObjetivoAsync(int usuarioId, int objetivoId)
  {
    return await _context.ObjetivosUsuario
      .Include(ou => ou.ObjetivoEducativo)
      .FirstOrDefaultAsync(ou => ou.UsuarioId == usuarioId && ou.ObjetivoEducativoId == objetivoId);
  }

  public async Task UpdateAsync(ObjetivoUsuario objetivoUsuario)
  {
    _context.ObjetivosUsuario.Update(objetivoUsuario);
    await _context.SaveChangesAsync();
  }
  
  public async Task DeleteAsync(ObjetivoUsuario objetivoUsuario)
  {
    _context.ObjetivosUsuario.Remove(objetivoUsuario);
    await _context.SaveChangesAsync();
  }
}
