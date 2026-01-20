using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.data.models.registros;

public class RegistroScout
{
  [Key, ForeignKey("Registro")]
  public int GestionId { get; set; }
  public int UserId { get; set; }
  
  [MaxLength(70)] public string UnidadEducativa { get; set; } = string.Empty;
  [MaxLength(30)] public string Curso { get; set; } = string.Empty;
  [MaxLength(15)] public string Etapa { get; set; } = string.Empty;
  
  public Registro Registro { get; set; } = null!;
}
