using backend.data;
using backend.data.models.registros;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class GestionRepository: IGestionRepository
{
  private readonly ScoutsAppContext _context;

  public GestionRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<Gestion?> GetGestionActual()
  {
    return await _context.Gestiones.FirstOrDefaultAsync(x => x.Active);
  }

  public async Task<Gestion?> GetUltimaGestion()
  {
    return await _context.Gestiones.OrderBy(g => g.Id).LastOrDefaultAsync();
  }
  
  public async Task<Gestion?> CreateGestion(Gestion gestion)
  {
    await _context.Gestiones.AddAsync(gestion);
    await _context.SaveChangesAsync();
    return gestion;
  }
}
