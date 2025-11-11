namespace backend.dtos.responses;

public class UnidadResponseDto
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public string Codigo { get; set; }
  public int GrupoScoutId { get; set; }
  public string GrupoScoutNombre { get; set; }
  public int RamaId { get; set; }
  public string RamaNombre { get; set; }
}
