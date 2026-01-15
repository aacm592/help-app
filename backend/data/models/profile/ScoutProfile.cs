using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.data.models.profile;

public class ScoutProfile
{
  [Key, ForeignKey("Profile")]
  public int Id { get; set; }
  
  [MaxLength(70)]
  public string UnidadEducativa { get; set; } = string.Empty;
  
  [MaxLength(30)]
  public string Curso { get; set; } = string.Empty;

  [MaxLength(15)]
  public string Etapa { get; set; } = string.Empty;
  public UserProfile UserProfile { get; set; } = null!;
}
