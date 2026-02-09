namespace backend.dtos.responses;

public class UserResponseDto
{
  public int Id { get; set; }
  public string Nombre { get; set; } =  string.Empty;
  public string NombreUsuario { get; set; } = string.Empty;
  public DateTime FechaNacimiento { get; set; }
  public int TipoId { get; set; }
  public string TipoNombre { get; set; } = string.Empty;
  public ICollection<PermisoResponseDto> Permisos { get; set; } = new List<PermisoResponseDto>();
  public ICollection<UnidadResponseDto> Unidades { get; set; } = new List<UnidadResponseDto>();
}
