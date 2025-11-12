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

  public async Task<bool> CodigoExists(string codigo)
  {
    return await _context.Unidades
      .AnyAsync(u => u.Codigo.ToUpper() == codigo.ToUpper());
  }
  
  public async Task<Unidad?> GetByCodigoAsync(string codigo)
  {
    return await _context.Unidades
      .Include(u => u.Usuarios)
      .Include(u => u.Rama)
      .Include(u => u.GrupoScout)
      .FirstOrDefaultAsync(u => u.Codigo == codigo);
  }

  public async Task UpdateAsync(Unidad unidad)
  {
    _context.Unidades.Update(unidad);
    await _context.SaveChangesAsync();
  }
  
  public async Task<Unidad?> GetByIdWithMiembrosAsync(int unidadId)
  {
    return await _context.Unidades
      .Include(u => u.Usuarios)
      .ThenInclude(user => user.Tipo)
      .FirstOrDefaultAsync(u => u.Id == unidadId);
  }
  
  public async Task DeleteAsync(Unidad unidad)
  {
    _context.Unidades.Remove(unidad);
    await _context.SaveChangesAsync();
  }
}
