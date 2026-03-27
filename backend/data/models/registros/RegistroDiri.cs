using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.data.models.registros;

public class RegistroDiri
{
  [Key, ForeignKey("Registro")]
  public int GestionId { get; set; }
  public int UserId { get; set; }
  
  [MaxLength(30)] public string Profesion { get; set; } = string.Empty;
  [MaxLength(30)] public string Ocupacion { get; set; } = string.Empty;
  [MaxLength(100)] public string Cargo1 { get; set; } = string.Empty;
  [MaxLength(100)] public string Cargo2 { get; set; } = string.Empty;
  
  public Registro Registro { get; set; } = null!;
}
