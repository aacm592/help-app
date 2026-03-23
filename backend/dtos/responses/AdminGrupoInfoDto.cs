namespace backend.dtos.responses;

public class AdminGrupoInfoDto: AdminInfoDto
{
  public string Grupo {get; set; } = string.Empty;
  public int GrupoId {get; set; }
  public int Telf {get; set; }
}
