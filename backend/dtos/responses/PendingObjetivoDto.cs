namespace backend.dtos.responses;

public class PendingObjetivoDto
{
  public int UsuarioId { get; set; }
  public string NombreScout { get; set; }
  public int ObjetivoId { get; set; }
  public string ObjetivoDescripcion { get; set; }
  public string Status { get; set; }
  public string AreaNombre { get; set; }
}
