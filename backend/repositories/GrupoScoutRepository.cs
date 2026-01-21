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

  public async Task<GrupoScout?> GetById(int id)
  {
    return await _context.GruposScout
      .Include(g => g.Unidades)
      .ThenInclude(u => u.Usuarios)
      .ThenInclude(u => u.Profile)
      .Include(g => g.Unidades)
      .ThenInclude(u => u.Usuarios)
      .ThenInclude(u => u.Tipo)
      .FirstOrDefaultAsync(g => g.Id == id);
  }
}
