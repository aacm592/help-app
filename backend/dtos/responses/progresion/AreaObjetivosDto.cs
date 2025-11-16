namespace backend.dtos.responses.progresion;

public class AreaObjetivosDto
{
  public int Id { get; set; }
  public string Nombre { get; set; } = string.Empty;
  public List<ObjetivoUsuarioResponseDto> Objetivos { get; set; } = new List<ObjetivoUsuarioResponseDto>();
}
