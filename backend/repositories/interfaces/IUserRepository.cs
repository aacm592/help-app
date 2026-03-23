using backend.data.models;

namespace backend.repositories.interfaces;
public interface IUserRepository 
{ 
  Task<User?> GetByUsernameAsync(string username); 
  Task<User> AddAsync(User user);
  Task<User?> GetByIdAsync(int id);
  Task<User?> GetByIdWithTipoAndUnidadesAsync(int userId);
  Task UpdateAsync(User user);
  Task<IEnumerable<User>?> GetUsersByPermiso(int[] permisoIds, int gestionId);
  Task<IEnumerable<User>?> GetUsersByPermisoAndArea(int[] permisoIds, int areaId, int gestionId);
}
