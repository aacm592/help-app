using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IPermisosService
{
  Task AddGroupAdmin(int userId, string username);
  Task DeleteGroupAdmin(int userId, int adminId);
  Task AddDistritoAdmin(int userId, string username);
  Task DeleteDistritoAdmin(int userId, int adminId);
  Task AddResponsableGrupo(int userId, CatalogDto user);
  Task DeleteResponsableGrupo(int userId, int adminId);
}
