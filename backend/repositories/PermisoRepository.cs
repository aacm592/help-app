using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class PermisoRepository: IPermisoRepository
{
  private readonly ScoutsAppContext _context;

  public PermisoRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task AddPermiso(UserPermiso permiso)
  {
    _context.UserPermisos.Add(permiso);
    await _context.SaveChangesAsync();
  }

  public async Task<IEnumerable<UserPermiso>> GetPermisosByUserId(int userId)
  {
    return await _context.UserPermisos.Where(p => p.UserId == userId).ToListAsync();
  }

  public async Task Delete(UserPermiso permiso)
  {
    _context.UserPermisos.Remove(permiso);
    await _context.SaveChangesAsync();
  }
}
