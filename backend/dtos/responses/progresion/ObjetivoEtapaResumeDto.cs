namespace backend.dtos.responses.progresion;

public class ObjetivoEtapaResumeDto
{
  public string Etapa { get; set; } = string.Empty;
  public List<ObjetivoAreaResumeDto> ObjetivosAreaResume { get; set; } = new();
}
