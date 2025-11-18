using System.ComponentModel.DataAnnotations;

namespace backend.dtos.request;

public class ChangePasswordDto
{
  [Required]
  public string ContrasenaActual { get; set; } = string.Empty;

  [Required]
  public string NuevaContrasena { get; set; } = string.Empty;
}
