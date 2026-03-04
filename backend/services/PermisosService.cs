using backend.data.models;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class PermisosService : IPermisosService
{
  private readonly IPermisoRepository _permisoRepository;
  private readonly IUserRepository _userRepository;

  public PermisosService(IPermisoRepository permisoRepository, IUserRepository userRepository)
  {
    _permisoRepository = permisoRepository;
    _userRepository = userRepository;
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

    if (scout.Unidades.Count == 0)
      return;

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

  private bool VerifyPermisos(IEnumerable<UserPermiso> permisos, int permiso)
  {
    if (permisos.FirstOrDefault(p => p.PermisoId == permiso) != null)
      return true;
    return false;
  }
}
