using System.ComponentModel.DataAnnotations;

namespace backend.dtos.request;

public class ValidarObjetivoDto
{
  [Required]
  public int UsuarioId { get; set; }

  [Required]
  public int ObjetivoId { get; set; }
}