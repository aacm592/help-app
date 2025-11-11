namespace backend.data.models;

public class ObjetivoUsuario
{
  public int UsuarioId { get; set; }
  public User User { get; set; }

  public int ObjetivoEducativoId { get; set; }
  public ObjetivoEducativo ObjetivoEducativo { get; set; }

  public string Status { get; set; }
}
