namespace backend.dtos.auth;

public class RegisterDto
{
  public string Nombre { get; set; }
  public DateTime FechaNacimiento { get; set; }
  public string NombreUsuario { get; set; }
  public string Contrasena { get; set; }
}
