using System.ComponentModel.DataAnnotations;

namespace backend.data.models.especialidades;

public class Especialidad
{
  public int Id { get; set; }
  
  public int RamaId { get; set; }
  public Rama Rama { get; set; } =  null!;

  [MaxLength(500)]
  public string Descripcion { get; set; } = string.Empty;

  [MaxLength(40)]
  public string Nombre { get; set; } = string.Empty;
  
  public ICollection<RequisitoEsp> Requisitos { get; set; } = new List<RequisitoEsp>();
}
