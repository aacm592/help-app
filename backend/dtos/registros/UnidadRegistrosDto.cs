using backend.dtos.registros;
using backend.dtos.responses;

namespace backend.dtos.registros;

public class UnidadRegistrosDto: CatalogDto
{
  public List<UserRegistrosDto<ScoutInfoDto>> Scouts { get; set; } = new();
  public List<UserRegistrosDto<DiriInfoDto>> Dirigentes { get; set; } = new();
}
