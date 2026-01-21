namespace backend.dtos.registros;

public class UserDataDto
{
  public int Id { get; set; }
  public string Nombre { get; set; } = string.Empty;
  public int Edad { get; set; }
  public string Rol { get; set; } = string.Empty;
}
