namespace backend.dtos.auth;

public class LoginDto
{
  public string NombreUsuario { get; set; } = string.Empty;
  public string Contrasena { get; set; } = string.Empty;
}
