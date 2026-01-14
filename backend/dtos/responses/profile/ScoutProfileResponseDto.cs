namespace backend.dtos.responses.profile;

public class ScoutProfileResponseDto : ProfileResponseDto
{
  public string UnidadEducativa { get; set; } = string.Empty;
  public string Curso { get; set; } = string.Empty;
}
