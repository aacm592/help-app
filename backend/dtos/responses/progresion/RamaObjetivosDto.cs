namespace backend.dtos.responses.progresion;

public class RamaObjetivosDto
{
  public int Id { get; set; }
  public string Nombre { get; set; } = string.Empty;
  public List<EtapaObjetivosDto> Etapas { get; set; } = new List<EtapaObjetivosDto>();
}
