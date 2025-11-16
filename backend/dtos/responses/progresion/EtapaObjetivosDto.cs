namespace backend.dtos.responses.progresion;

public class EtapaObjetivosDto
{
  public int Id { get; set; }
  public string Nombre { get; set; } = string.Empty;
  public List<AreaObjetivosDto> Areas { get; set; } = new List<AreaObjetivosDto>();
}
