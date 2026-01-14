namespace backend.dtos.request.profile;

public class ProfileRequestDto
{
  public string Nombre { get; set; } = string.Empty;
  public string Apellido { get; set; } = string.Empty;
  public int Ci { get; set; }
  public string ComplementoCi { get; set; } = string.Empty;
  public int Telf { get; set; }
  public string Genero { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
}
