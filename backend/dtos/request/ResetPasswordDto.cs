using System.ComponentModel.DataAnnotations;

namespace backend.dtos.request;

public class ResetPasswordDto
{
  [Required]
  public string NombreUsuario { get; set; } = string.Empty;
    
  [Required]
  public string ResetCode { get; set; } = string.Empty;

  [Required]
  public string NuevaContrasena { get; set; } = string.Empty;
}
