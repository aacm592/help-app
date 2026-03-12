using backend.data.models;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class PermisosService : IPermisosService
{
  private readonly IPermisoRepository _permisoRepository;
  private readonly IUserRepository _userRepository;
  private readonly IGrupoScoutRepository _grupoScoutRepository;

  public PermisosService(IPermisoRepository permisoRepository, IUserRepository userRepository, IGrupoScoutRepository grupoScoutRepository)
  {
    _permisoRepository = permisoRepository;
    _userRepository = userRepository;
    _grupoScoutRepository = grupoScoutRepository;
  }

  public async Task AddGroupAdmin(int userId, string username)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado");

    var permiso = user.UserPermisos.FirstOrDefault(p => p.PermisoId == 1);
    if (permiso == null)
      throw new ApplicationException("No tienes los permisos necesarios");

    var scout = await _userRepository.GetByUsernameAsync(username);
    if (scout == null)
      throw new ApplicationException("Usuario no encontrado");

    if (VerifyPermisos(scout.UserPermisos, 1) || VerifyPermisos(scout.UserPermisos, 2))
      throw new ApplicationException("No se puedieron dar los permisos al usuario");

    if (scout.Unidades.Any())
    {
      var unidad = scout.Unidades.First();
        
      if (unidad.GrupoScoutId != permiso.AreaId)
        throw new ApplicationException("El usuario pertenece a un grupo diferente.");
    }

    if (!user.Unidades.Any(u => u.GrupoScoutId == permiso.AreaId))
      throw new ApplicationException("El usuario no pertenece a tu grupo");

    var newPermiso = new UserPermiso()
    {
      PermisoId = 2,
      UserId = scout.Id,
      AreaId = permiso.AreaId
    };

     await _permisoRepository.AddPermiso(newPermiso);
  }

  public async Task DeleteGroupAdmin(int userId, int adminId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado");

    var permisoEjecutor = user.UserPermisos.FirstOrDefault(p => p.PermisoId == 1);
    if (permisoEjecutor == null)
      throw new ApplicationException("No tienes los permisos necesarios");

    var permisosAdminEliminar = await _permisoRepository.GetPermisosByUserId(adminId);
    
    var permisoAEliminar = permisosAdminEliminar.FirstOrDefault(p => 
      (p.PermisoId == 2) && p.AreaId == permisoEjecutor.AreaId);

    if (permisoAEliminar == null)
      throw new ApplicationException("El usuario no tiene permisos de administrador en este grupo");

    await _permisoRepository.Delete(permisoAEliminar);
  }
  
  public async Task AddDistritoAdmin(int userId, string username)
{
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
        throw new ApplicationException("Usuario no encontrado");

    var permisoDistrito = user.UserPermisos.FirstOrDefault(p => p.PermisoId == 3);
    if (permisoDistrito == null)
        throw new ApplicationException("No tienes los permisos necesarios.");

    var scout = await _userRepository.GetByUsernameAsync(username);
    if (scout == null)
        throw new ApplicationException("Usuario no encontrado");

    if (VerifyPermisos(scout.UserPermisos, 3) || VerifyPermisos(scout.UserPermisos, 4))
        throw new ApplicationException("El usuario ya posee cargos administrativos de distrito.");

    if (scout.Unidades.Any())
    {
        var unidad = scout.Unidades.First();
        var grupo = await _grupoScoutRepository.GetById(unidad.GrupoScoutId);
        
        if (grupo == null || grupo.DistritoId != permisoDistrito.AreaId)
            throw new ApplicationException("El usuario pertenece a un grupo fuera de tu distrito.");
    }
    
    var permisoGrupoPrevio = scout.UserPermisos.FirstOrDefault(p => p.PermisoId == 1 || p.PermisoId == 2);
    if (permisoGrupoPrevio != null)
    {
        var grupoDelPermiso = await _grupoScoutRepository.GetById(permisoGrupoPrevio.AreaId);
        if (grupoDelPermiso == null || grupoDelPermiso.DistritoId != permisoDistrito.AreaId)
            throw new ApplicationException("El usuario pertenece a un grupo fuera de tu distrito.");
    }

    var newPermiso = new UserPermiso()
    {
        PermisoId = 4,
        UserId = scout.Id,
        AreaId = permisoDistrito.AreaId
    };

    await _permisoRepository.AddPermiso(newPermiso);
}
  
  public async Task DeleteDistritoAdmin(int userId, int adminId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado");

    var permisoEjecutor = user.UserPermisos.FirstOrDefault(p => p.PermisoId == 3);
    if (permisoEjecutor == null)
      throw new ApplicationException("No tienes los permisos necesarios");

    var permisosAdminEliminar = await _permisoRepository.GetPermisosByUserId(adminId);
    
    var permisoAEliminar = permisosAdminEliminar.FirstOrDefault(p => 
      (p.PermisoId == 4) && p.AreaId == permisoEjecutor.AreaId);

    if (permisoAEliminar == null)
      throw new ApplicationException("El usuario no tiene permisos de administrador en este distrito");

    await _permisoRepository.Delete(permisoAEliminar);
  }

  private bool VerifyPermisos(IEnumerable<UserPermiso> permisos, int permiso)
  {
    if (permisos.FirstOrDefault(p => p.PermisoId == permiso) != null)
      return true;
    return false;
  }
}
