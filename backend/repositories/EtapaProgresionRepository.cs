using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class EtapaProgresionRepository: IEtapaProgresionRepository
{
  private readonly ScoutsAppContext _context;

  public EtapaProgresionRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<EtapaProgresion>> GetByRamaIdAsync(int ramaId)
  {
    return await _context.EtapasProgresion
      .Where(e => e.RamaId == ramaId)
      .ToListAsync();
  }
}