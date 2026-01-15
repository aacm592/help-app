namespace backend.dtos.responses.progresion;

public class ObjetivoAreaResumeDto
{
  public string Area { get; set; } = string.Empty;
  public int TotalQuantity { get; set; }
  public int InProgressQuantity { get; set; }
  public int DoneQuantity {get; set;}
}
