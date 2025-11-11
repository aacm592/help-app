using System.ComponentModel.DataAnnotations;

namespace backend.dtos.request;

public class ElegirObjetivoDto
{
  [Required]
  public int ObjetivoId { get; set; }
}
