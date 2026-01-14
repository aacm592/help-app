namespace backend.dtos.request.profile;

public class DiriProfileRequestDto : ProfileRequestDto
{
  public string Profesion { get; set; } = string.Empty;
  public string Ocupacion { get; set; } = string.Empty;
}
