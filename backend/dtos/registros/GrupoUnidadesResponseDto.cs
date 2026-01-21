namespace backend.dtos.registros;

public class GrupoUnidadesResponseDto
{
  public int Id { get; set; }
  public string Nombre { get; set; } = string.Empty;
  public List<UserDataDto> Usuarios { get; set; } = new List<UserDataDto>();
}