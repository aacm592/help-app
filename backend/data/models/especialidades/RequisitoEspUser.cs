using System.ComponentModel.DataAnnotations.Schema;
using backend.enums;

namespace backend.data.models.especialidades;

public class RequisitoEspUser
{
  public int UsuarioId { get; set; }
  public User Usuario { get; set; } =  null!;
  
  public int RequisitoId { get; set; }
  public RequisitoEsp Requisito { get; set; } =  null!;
  
  public DateTime FechaSeleccion { get; set; } 
  public DateTime? FechaAprobacion { get; set; }
  
  public int? DirigenteAproboId { get; set; }
  [ForeignKey("DirigenteAproboId")]
  public User? DirigenteAprobo { get; set; }
  
  public ObjetivoStatus Status { get; set; }
}
