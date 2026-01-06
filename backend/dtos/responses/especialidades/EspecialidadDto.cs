namespace backend.dtos.responses.especialidades;

public class EspecialidadDto
{
  public string Nombre { get; set; } = string.Empty;
  public string Descripcion { get; set; } = string.Empty;
  public int IdEspecialidad { get; set; }
  public string Status { get; set; } = string.Empty;
  public ICollection<EspecialidadReqDto> Requerimientos { get; set; } = new List<EspecialidadReqDto>();
}
