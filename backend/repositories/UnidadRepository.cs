using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class UnidadRepository: IUnidadRepository
{
  private readonly ScoutsAppContext _context;

  public UnidadRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<Unidad> Add(Unidad unidad)
  {
    _context.Unidades.Add(unidad);
    await _context.SaveChangesAsync();
    return unidad;
  }

  public async Task<Unidad?> GetByCodigo(string codigo)
  {
    return await _context.Unidades
      .FirstOrDefaultAsync(u => u.Codigo.ToUpper() == codigo.ToUpper());
  }

  public async Task<bool> CodigoExists(string codigo)
  {
    return await _context.Unidades
      .AnyAsync(u => u.Codigo.ToUpper() == codigo.ToUpper());
  }
}
