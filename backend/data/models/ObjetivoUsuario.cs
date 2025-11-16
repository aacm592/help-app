using backend.enums;

namespace backend.data.models;

public class ObjetivoUsuario
{
  public int UsuarioId { get; set; }
  public User User { get; set; } =  null!;

  public int ObjetivoEducativoId { get; set; }
  public ObjetivoEducativo ObjetivoEducativo { get; set; } =  new ObjetivoEducativo();

  public ObjetivoStatus Status { get; set; }
}
