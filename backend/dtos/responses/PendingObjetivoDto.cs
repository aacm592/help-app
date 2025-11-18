namespace backend.dtos.responses;

public class PendingObjetivoDto
{
  public int UsuarioId { get; set; }
  public string NombreScout { get; set; } = string.Empty;
  public int ObjetivoId { get; set; }
  public string ObjetivoDescripcion { get; set; } = string.Empty;
  public string Status { get; set; } = string.Empty;
  public string AreaNombre { get; set; } = string.Empty;
  public DateTime FechaSeleccion { get; set; }
}
