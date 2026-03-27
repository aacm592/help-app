using backend.data.models;

namespace backend.repositories.interfaces;

public interface IPermisoRepository
{
  Task AddPermiso(UserPermiso permiso);
  Task<IEnumerable<UserPermiso>> GetPermisosByUserId(int userId);
  Task Delete(UserPermiso userPermiso);
}
