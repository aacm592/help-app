using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class RamaRepository : IRamaRepository
{
  private readonly ScoutsAppContext _context;

  public RamaRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Rama>> GetAll()
  {
    return await _context.Ramas.OrderBy(r => r.EdadMinima).ToListAsync();
  }
}
