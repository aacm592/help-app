using backend.data.models;
using backend.data.models.registros;
using backend.dtos.registros;

namespace backend.repositories.interfaces;

public interface IRegistroRepository
{
  Task<Registro> Create(Registro registro);
  Task Update();
  Task<Registro?> GetRegistroByUserId(int userId, int gestionId);
  Task<List<Registro>> GetMany(IEnumerable<int> userIds, int gestionId);
  Task<GrupoScout?> GetGroupRegisters(int id, int gestionId);
  Task<GrupoScout?> GetGroupRegistersByRama(int id, int gestionId, int ramaId);
  Task<IEnumerable<Registro?>> GetRegistersByPermisoAndArea(int[] permisoIds, int areaId, int gestionId);
  Task<IEnumerable<Registro>> GetRegistersByDistritoName(string distrito, int gestionId);
  Task<IEnumerable<Registro>> GetRegistersByDistritoAndGrupoName(string distrito, string grupo, int gestionId);
  Task Delete(Registro registro);
}
