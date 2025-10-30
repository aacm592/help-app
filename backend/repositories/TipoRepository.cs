using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class TipoRepository : ITipoRepository
{
  private readonly ScoutsAppContext _context;

  public TipoRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<Tipo?> GetByNameAsync(string nombre)
  {
    return await _context.Tipos
      .FirstOrDefaultAsync(t => t.Nombre.ToLower() == nombre.ToLower());
  }
}
