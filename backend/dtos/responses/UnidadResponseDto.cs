namespace backend.dtos.responses;

public class UnidadResponseDto
{
  public int Id { get; set; }
  public string Nombre { get; set; } =  string.Empty;
  public string Codigo { get; set; } = string.Empty;
  public int GrupoScoutId { get; set; }
  public string GrupoScoutNombre { get; set; } = string.Empty;
  public int RamaId { get; set; }
  public string RamaNombre { get; set; } = string.Empty;
}
