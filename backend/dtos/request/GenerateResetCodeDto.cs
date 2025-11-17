using System.ComponentModel.DataAnnotations;

namespace backend.dtos.request;

public class GenerateResetCodeDto
{
  [Required]
  public int ScoutId { get; set; }
}
