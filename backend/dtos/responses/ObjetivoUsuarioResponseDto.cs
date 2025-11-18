namespace backend.dtos.responses;

public class ObjetivoUsuarioResponseDto
{
  public int UsuarioId { get; set; }
  public int ObjetivoId { get; set; }
  public string Status { get; set; } = string.Empty;
  public string ObjetivoDescripcion { get; set; } = string.Empty;
  public string AreaNombre { get; set; } = string.Empty;
  public DateTime FechaSeleccion { get; set; }
  public DateTime? FechaAprobacion { get; set; }
  public int? DirigenteAproboId { get; set; }
  public string? DirigenteAproboNombre { get; set; }
}
