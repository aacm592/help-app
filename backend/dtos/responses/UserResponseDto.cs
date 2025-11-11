namespace backend.dtos.responses;

public class UserResponseDto
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public string NombreUsuario { get; set; }
  public DateTime FechaNacimiento { get; set; }
  public int TipoId { get; set; }
  public ICollection<UnidadResponseDto> Unidades { get; set; } = new List<UnidadResponseDto>();
}