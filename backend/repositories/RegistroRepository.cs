using backend.data;
using backend.data.models;
using backend.data.models.registros;
using backend.enums;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class RegistroRepository: IRegistroRepository
{
  private readonly ScoutsAppContext _context;

  public RegistroRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<Registro> Create(Registro registro)
  {
    await _context.Registros.AddAsync(registro);
    await Update();
    return registro;
  }

  public async Task Update()
  {
    await _context.SaveChangesAsync();
  }

  public async Task<Registro?> GetRegistroByUserId(int userId, int gestionId)
  {
    return await _context.Registros.FirstOrDefaultAsync(x => x.UserId == userId && x.GestionId == gestionId);
  }

  public async Task<List<Registro>> GetMany(IEnumerable<int> userIds, int gestionId)
  {
    var ids = userIds.ToList(); 

    return await _context.Registros
      .Where(r => r.GestionId == gestionId && ids.Contains(r.UserId))
      .ToListAsync();
  }

  public async Task<GrupoScout?> GetGroupRegisters(int id, int gestionId)
  {
    return await _context.GruposScout
      .AsNoTracking()
      .Include(g => g.Unidades)
      .ThenInclude(u => u.Usuarios.Where(x => x.Registros.FirstOrDefault(r => r.GestionId == gestionId) != null))
      .ThenInclude(u => u.Registros.Where(x => x.GestionId == gestionId))
      .ThenInclude(r => r.RegistroDiri)
      .Include(g => g.Unidades)
      .ThenInclude(u => u.Usuarios.Where(x => x.Registros.FirstOrDefault(r => r.GestionId == gestionId) != null))
      .ThenInclude(u => u.Registros.Where(x => x.GestionId == gestionId))
      .ThenInclude(r => r.RegistroScout)
      .FirstOrDefaultAsync(g => g.Id == id);
  }

  public async Task<GrupoScout?> GetGroupRegistersByRama(int id, int gestionId, int ramaId)
  {
    return await _context.GruposScout
      .AsNoTracking()
      .Include(g => g.Unidades.Where(u => u.RamaId == ramaId))
      .ThenInclude(u => u.Usuarios.Where(x => x.Registros.FirstOrDefault(r => r.GestionId == gestionId) != null))
      .ThenInclude(u => u.Registros.Where(x => x.GestionId == gestionId))
      .ThenInclude(r => r.RegistroScout)
      .Include(g => g.Unidades.Where(u => u.RamaId == ramaId))
      .ThenInclude(u => u.Usuarios.Where(x => x.Registros.FirstOrDefault(r => r.GestionId == gestionId) != null))
      .ThenInclude(u => u.Registros.Where(x => x.GestionId == gestionId))
      .ThenInclude(r => r.RegistroDiri)
      .FirstOrDefaultAsync(g => g.Id == id);
  }

  public async Task<IEnumerable<Registro>> GetRegistersByDistritoName(string distrito, int gestionId)
  {
    return await _context.Registros
      .Include(r => r.RegistroDiri)
      .Include(r => r.RegistroScout)
      .Where(r => r.Distrito == distrito && r.GestionId == gestionId && r.Status == RegistroStatus.EnviadoDistrito)
      .ToListAsync();
  }
  
  public async Task<IEnumerable<Registro>> GetRegistersByDistritoAndGrupoName(string distrito, string grupo, int gestionId)
  { 
    return await _context.Registros
      .Include(r => r.RegistroDiri)
      .Include(r => r.RegistroScout)
      .Where(r => r.Distrito == distrito && r.GestionId == gestionId && r.Grupo == grupo)
      .ToListAsync();
  }
  
  
  public async Task<IEnumerable<Registro?>> GetRegistersByPermisoAndArea(int[] permisoIds, int areaId, int gestionId)
  {
    return await _context.Registros
      .Include(r => r.RegistroDiri)
      .Include(r => r.RegistroScout)
      .Where(r => r.User.UserPermisos.Any(p => permisoIds.Contains(p.PermisoId) && p.AreaId == areaId) && r.GestionId == gestionId)
      .ToListAsync();
  }

  public async Task Delete(Registro registro)
  {
    _context.Registros.Remove(registro);
    await Update();
  }
}
