namespace backend.dtos.responses;

public class AdminInfoDto
{
  public int Id { get; set; }
  public string Nombre { get; set; } = string.Empty;
  public string Permiso { get; set; } = string.Empty;
  public string RegistroStatus { get; set; } = string.Empty;
}
