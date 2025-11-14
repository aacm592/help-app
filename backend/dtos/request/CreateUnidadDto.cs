namespace backend.dtos.request;

public class CreateUnidadDto
{
  public string Nombre { get; set; } = string.Empty;
  public int GrupoScoutId { get; set; }
  public int RamaId { get; set; }
}
