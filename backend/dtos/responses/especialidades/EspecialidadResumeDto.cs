namespace backend.dtos.responses.especialidades;

public class EspecialidadResumeDto
{
  public string Name { get; set; } = string.Empty;
  public string Status { get; set; } = string.Empty;
  public int RequirementQuantity { get; set; }
  public int InProgressQuantity { get; set; }
  public int DoneQuantity {get; set;}
}
