namespace backend.dtos.auth;

public class RegisterDto
{
  public string Nombre { get; set; } = string.Empty;
  public DateTime FechaNacimiento { get; set; }
  public string NombreUsuario { get; set; } = string.Empty;
  public string Contrasena { get; set; } = string.Empty;
}
