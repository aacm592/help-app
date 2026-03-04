using backend.data.models;
using backend.data.models.registros;

namespace backend.repositories.interfaces;

public interface IRegistroRepository
{
  Task<Registro> Create(Registro registro);
  Task Update();
  Task<Registro?> GetRegistroByUserId(int userId, int gestionId);
  Task<GrupoScout?> GetGroupRegisters(int id, int gestionId);
  Task<GrupoScout?> GetGroupRegistersByRama(int id, int gestionId, int ramaId);
  Task<IEnumerable<Registro?>> GetRegistersByPermisoAndArea(int[] permisoIds, int areaId, int gestionId);
  Task Delete(Registro registro);
}
