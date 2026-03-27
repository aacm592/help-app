using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;
public class UserRepository : IUserRepository
{
  private readonly ScoutsAppContext _context;

  public UserRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<User?> GetByUsernameAsync(string username)
  {
    return await _context.Users
      .Include(u => u.Profile)
      .Include(u => u.Tipo)
      .Include(u => u.UserPermisos)
      .ThenInclude(u => u.Permiso)
      .Include(u => u.Unidades)
      .ThenInclude(un => un.Rama)
      .Include(u => u.Unidades)
      .ThenInclude(un => un.GrupoScout)
      .FirstOrDefaultAsync(u => u.NombreUsuario == username);
  }

  public async Task<User> AddAsync(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync(); 
    return user;
  }
    
  public async Task<User?> GetByIdAsync(int id)
  {
    return await _context.Users
      .Include(u => u.Profile)
      .Include(u => u.Unidades)
      .FirstOrDefaultAsync(u => u.Id == id);
  }
    
  public async Task<User?> GetByIdWithTipoAndUnidadesAsync(int userId)
  {
    return await _context.Users
      .Include(u => u.Profile)
      .ThenInclude(p => p!.ScoutProfile)
      .Include(u => u.Profile)
      .ThenInclude(p => p!.DiriProfile)
      .Include(u => u.Tipo)
      .Include(u => u.UserPermisos)
      .Include(u => u.Unidades)
        .ThenInclude(un => un.Rama)
      .Include(u => u.Unidades)
        .ThenInclude(un => un.GrupoScout)
      .FirstOrDefaultAsync(u => u.Id == userId);
  }

  public async Task<IEnumerable<User>?> GetUsersByPermiso(int[] permisoIds, int gestionId)
  {
    return await _context.Users
      .Include(u => u.Profile)
      .ThenInclude(p => p!.ScoutProfile)
      .Include(u => u.Profile)
      .ThenInclude(p => p!.DiriProfile)     
      .Include(u => u.Registros.Where(r => r.GestionId == gestionId))
      .Include(u => u.Tipo)
      .Include(u => u.UserPermisos)
      .ThenInclude(p => p.Permiso)
      .Where(u => u.UserPermisos.Any(p => permisoIds.Contains(p.PermisoId)))
      .ToListAsync();
  }
  
  public async Task<IEnumerable<User>?> GetUsersByPermisoAndArea(int[] permisoIds, int areaId, int gestionId)
  {
    return await _context.Users
      .Include(u => u.Profile)
      .ThenInclude(p => p!.ScoutProfile)
      .Include(u => u.Profile)
      .ThenInclude(p => p!.DiriProfile)     
      .Include(u => u.Registros.Where(r => r.GestionId == gestionId))
      .Include(u => u.Tipo)
      .Include(u => u.UserPermisos)
      .ThenInclude(p => p.Permiso)
      .Where(u => u.UserPermisos.Any(p => permisoIds.Contains(p.PermisoId) && p.AreaId == areaId))
      .ToListAsync();
  }
  
  public async Task UpdateAsync(User user)
  {
    _context.Users.Update(user);
    await _context.SaveChangesAsync();
  }
}
