using backend.dtos.registros;
using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IGrupoScoutService
{
  Task<IEnumerable<CatalogDto>> GetAllAsync();
  Task<IEnumerable<CatalogDto>> GetByDistritoIdAsync(int distritoId);
  Task<IEnumerable<UnidadUsersDto>> UsersById(int id);
  Task<IEnumerable<UnidadUsersDto>> GetUsersByRamaId(int id, int ramaId);
  Task<IEnumerable<UnidadRegistrosDto>> GetRegistros(int id);
  Task<IEnumerable<UnidadRegistrosDto>> GetRegistrosByRama(int id, int ramaId);
  Task<IEnumerable<UnidadResumenDto>> GetUnidadesResumenByGrupo(int userId);
  Task<IEnumerable<UserDataDto<DiriInfoDto>>> GetAdmins(int userId);
  Task<IEnumerable<UserRegistrosDto<DiriInfoDto>>> GetAdminsRegisters(int userId);
  Task<ResumenRegistrosDto> GetResumenRegistros(int userId);
}
