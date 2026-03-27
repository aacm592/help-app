using backend.dtos.registros;

namespace backend.dtos.responses;

public class UnidadUsersDto: CatalogDto
{
  public string Rama { get; set; } = string.Empty;
  public List<UserDataDto<ScoutInfoDto>> Scouts { get; set; } = new();
  public List<UserDataDto<DiriInfoDto>> Dirigentes { get; set; } = new();
}
