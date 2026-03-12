using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class DistritoRepository: IDistritoRepository
{
  private readonly ScoutsAppContext _context;

  public DistritoRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Distrito>> GetAll()
  {
    return await _context.Distritos.OrderBy(d => d.Nombre).ToListAsync();
  }

  public async Task<Distrito?> GetDistritoById(int id)
  {
    return await _context.Distritos.FindAsync(id);
  }
}
