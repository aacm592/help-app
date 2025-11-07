using backend.data.models;
using backend.dtos.request;
using backend.dtos.responses;

namespace backend.services.interfaces;

public interface IUnidadService
{
  Task<UnidadResponseDto> Create(CreateUnidadDto dto, int creadorId);
  Task<UnidadResponseDto> JoinUnidad(string codigo, int userId);
}
