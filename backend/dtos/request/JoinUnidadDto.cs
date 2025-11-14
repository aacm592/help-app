using System.ComponentModel.DataAnnotations;

namespace backend.dtos.request;

public class JoinUnidadDto
{
  [Required]
  public string Codigo { get; set; } = string.Empty;
}
