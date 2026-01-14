namespace backend.dtos.responses.profile;

public class ProfileResponseDto
{
  public int Id {get; set;}
  public string Nombre { get; set; } = string.Empty;
  public string Apellido { get; set; } = string.Empty;
  public DateTime FechaNacimiento { get; set; }
  public int Ci { get; set; }
  public string ComplementoCi { get; set; } = string.Empty;
  public int Telf { get; set; }
  public string Genero { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
}
