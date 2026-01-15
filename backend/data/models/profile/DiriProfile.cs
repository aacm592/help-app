using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.data.models.profile;

public class DiriProfile
{
  [Key, ForeignKey("Profile")]
  public int Id { get; set; }
  
  [MaxLength(30)]
  public string Profesion { get; set; } = string.Empty;
  
  [MaxLength(30)]
  public string Ocupacion { get; set; } = string.Empty;
  
  [MaxLength(100)]
  public string Cargo1 { get; set; } = string.Empty;
  
  [MaxLength(100)]
  public string Cargo2 { get; set; } = string.Empty;
  public UserProfile UserProfile { get; set; } = null!;
}
