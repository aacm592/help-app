using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.data.models;

public class UserProfile
{
  [Key, ForeignKey("User")]
  public int Id { get; set; }

  [MaxLength(60)]
  public string Nombre { get; set; } = string.Empty;
  
  public DateTime FechaNacimiento { get; set; }
  
  public User User { get; set; } = null!;
}
