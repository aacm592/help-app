namespace backend.dtos.registros;

public class UserRegistrosDto<TInfo>: UserDataDto<TInfo>
{
  public string Grupo { get; set; } = string.Empty;
  public string Distrito { get; set; } = string.Empty;
}
