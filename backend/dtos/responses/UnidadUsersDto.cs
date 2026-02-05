using backend.dtos.responses;

namespace backend.dtos.registros;

public class UnidadUsersDto: CatalogDto
{
  public List<UserDataDto<ScoutInfoDto>> Scouts { get; set; } = new();
  public List<UserDataDto<DiriInfoDto>> Dirigentes { get; set; } = new();
}
