namespace backend.dtos.responses;

public class PermisoResponseDto
{
  public int Id { get; set; }
  public string Nombre { get; set; }  = string.Empty;
  
  public int AreaId {get; set; }
}
