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
      .ThenInclude(u => u.Profile)
      .Include(ou => ou.ObjetivoEducativo)
      .ThenInclude(o => o.AreaCrecimiento)
      .Where(ou => ou.Status == ObjetivoStatus.Pendiente)
      .Where(ou => scoutIds.Contains(ou.UsuarioId))
      .OrderBy(ou => ou.User.Profile == null ? "" : ou.User.Profile.Nombre)
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

  public async Task<ISet<int>> GetUserObjetivoIdsAsync(int usuarioId)
  {
    var ids = await _context.ObjetivosUsuario
      .Where(ou => ou.UsuarioId == usuarioId)
      .Select(ou => ou.ObjetivoEducativoId)
      .ToListAsync();

    return ids.ToHashSet();
  }

  public async Task<IEnumerable<ObjetivoUsuario>> GetByUsuarioIdAsync(int usuarioId)
  {
    return await _context.ObjetivosUsuario
      .Include(ou => ou.ObjetivoEducativo)
      .ThenInclude(o => o.AreaCrecimiento)
      .ThenInclude(x => x.ObjetivosEducativos)
      .ThenInclude(o => o.EtapaProgresion)
      .Include(ou => ou.DirigenteAprobo)
      .ThenInclude(d => d!.Profile)
      .Where(ou => ou.UsuarioId == usuarioId)
      .OrderBy(ou => ou.Status)
      .ThenBy(ou => ou.ObjetivoEducativo.Descripcion)
      .ToListAsync();
  }

  public async Task<IEnumerable<ObjetivoUsuario>> GetByUsuarioIdWithFullTreeAsync(int usuarioId)
  {
    return await _context.ObjetivosUsuario
      .Include(ou => ou.ObjetivoEducativo)
      .ThenInclude(o => o.AreaCrecimiento)
      .Include(ou => ou.ObjetivoEducativo)
      .ThenInclude(o => o.EtapaProgresion)
      .ThenInclude(e => e.Rama)
      .Include(ou => ou.DirigenteAprobo)
      .ThenInclude(d => d!.Profile)
      .Where(ou => ou.UsuarioId == usuarioId)
      .OrderBy(ou => ou.ObjetivoEducativo.EtapaProgresion.Rama.Id)
      .ThenBy(ou => ou.ObjetivoEducativo.EtapaProgresion.Id)
      .ThenBy(ou => ou.Status)
      .ToListAsync();
  }
}
