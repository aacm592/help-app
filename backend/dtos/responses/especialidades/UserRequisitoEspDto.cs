namespace backend.dtos.responses.especialidades;

public class UserRequisitoEspDto
{
  public int RequerimientoId { get; set; }

  public string Especialidad { get; set; } = string.Empty;
  public int ScoutId { get; set; }
  public string ScoutNombre { get; set; } = string.Empty;
  public string Descripcion { get; set; } = string.Empty;
}
