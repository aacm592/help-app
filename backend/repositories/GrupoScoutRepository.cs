using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class GrupoScoutRepository : IGrupoScoutRepository
{
  private readonly ScoutsAppContext _context;

  public GrupoScoutRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<GrupoScout>> GetAll()
  {
    return await _context.GruposScout.OrderBy(g => g.Nombre).ToListAsync();
  }
  
  public async Task<IEnumerable<GrupoScout>> GetByDistritoIdAsync(int distritoId)
  {
    return await _context.GruposScout
      .Where(g => g.DistritoId == distritoId)
      .OrderBy(g => g.Nombre)
      .ToListAsync();
  }

  public async Task<GrupoScout?> GetByIdWithUsers(int id, int gestionId)
  {
    return await _context.GruposScout
      .Include(g => g.Distrito)
      .Include(g => g.Unidades)
      .ThenInclude(u => u.Usuarios)
      .ThenInclude(u => u.Profile)
      .Include(g => g.Unidades)
      .ThenInclude(u => u.Usuarios)
      .ThenInclude(u => u.Tipo)
      .Include(g => g.Unidades)
      .ThenInclude(u => u.Usuarios)
      .ThenInclude(u => u.Registros.Where(x => x.GestionId == gestionId))
      .FirstOrDefaultAsync(g => g.Id == id);
  }
  
  public async Task<GrupoScout?> GetByRamaWithUsers(int id, int gestionId, int ramaId)
  {
    return await _context.GruposScout
      .Include(g => g.Distrito)
      .Include(g => g.Unidades.Where(u => u.RamaId == ramaId))
      .ThenInclude(u => u.Usuarios)
      .ThenInclude(u => u.Profile)
      .Include(g => g.Unidades.Where(u => u.RamaId == ramaId))
      .ThenInclude(u => u.Usuarios)
      .ThenInclude(u => u.Tipo)
      .Include(g => g.Unidades.Where(u => u.RamaId == ramaId))
      .ThenInclude(u => u.Usuarios)
      .ThenInclude(u => u.Registros.Where(x => x.GestionId == gestionId))
      .FirstOrDefaultAsync(g => g.Id == id);
  }

  public async Task<GrupoScout?> GetById(int id)
  {
    return await _context.GruposScout
      .Include(g => g.Distrito)
      .Include(g => g.Unidades)
      .FirstOrDefaultAsync(g => g.Id == id);  
  }
}
