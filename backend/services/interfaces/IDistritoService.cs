using backend.dtos.registros;
using backend.dtos.responses;
using backend.enums;

namespace backend.services.interfaces;

public interface IDistritoService
{
  Task<IEnumerable<CatalogDto>> GetAllAsync();
  Task<IEnumerable<GroupRegistroResumen>> GetResumenRegistrosByDistritoId(int userId, List<RegistroStatus> status);
  Task<UnidadRegistrosDto> GetRegistrosDistrito(int userId, List<RegistroStatus> status);
  Task<IEnumerable<AdminInfoDto>> GetAdmins(int userId);
}
