using System.ComponentModel.DataAnnotations;

namespace backend.data.models.especialidades;

public class RequisitoEsp
{
  public int Id { get; set; }
  
  public int EspecialidadId { get; set; }
  public Especialidad Especialidad { get; set; } =  null!;
  
  [MaxLength(500)]
  public string Descripcion { get; set; } = string.Empty;

  public ICollection<RequisitoEspUser>? RequisitosEspUser { get; set; } = new List<RequisitoEspUser>();
}
