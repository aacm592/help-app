namespace backend.dtos.request.profile;

public class ScoutProfileRequestDto : ProfileRequestDto
{
  public string UnidadEducativa { get; set; } = string.Empty;
  public string Curso { get; set; } = string.Empty;
  public string Etapa { get; set; } = string.Empty;
}
