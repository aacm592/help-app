namespace backend.dtos.registros;

public class UserDataDto<TInfo>
{
  public int Id { get; set; }
  public string Nombre { get; set; } = string.Empty;
  public int Edad { get; set; }
  public string Rol { get; set; } = string.Empty;
  public string RegistroStatus { get; set; } = string.Empty;
  public TInfo Datos { get; set; } = default!;
}
