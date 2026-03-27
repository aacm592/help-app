using backend.data.models;
using backend.dtos.request;
using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IUnidadService
{
  Task<UnidadResponseDto> Create(CreateUnidadDto dto, int creadorId);
  Task<UnidadResponseDto> JoinUnidad(string codigo, int userId);
  Task SalirDeUnidadAsync(int unidadId, int usuarioId);
  Task RemoverDeUnidadAsync(int unidadId, int usuarioARemoverId, int dirigenteId);
  Task<IEnumerable<UserResponseDto>> GetMiembrosUnidadAsync(int unidadId, int dirigenteId);
  Task<UnidadUsersDto> GetUnidadMembersAndRegisters(int userId, int unidadId);  
}
