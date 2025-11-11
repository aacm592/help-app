using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class ObjetivoEducativoRepository: IObjetivoEducativoRepository
{
  private readonly ScoutsAppContext _context;

  public ObjetivoEducativoRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<ObjetivoEducativo>> GetByEtapaIdAsync(int etapaId)
  {
    return await _context.ObjetivosEducativos
      .Include(o => o.AreaCrecimiento)
      .Where(o => o.EtapaProgresionId == etapaId)
      .OrderBy(o => o.AreaCrecimiento.Nombre)
      .ThenBy(o => o.Id)
      .ToListAsync();
  }
  
  public async Task<ObjetivoEducativo?> GetByIdAsync(int id)
  {
    return await _context.ObjetivosEducativos
      .Include(o => o.EtapaProgresion)
      .FirstOrDefaultAsync(o => o.Id == id);
  }
}
