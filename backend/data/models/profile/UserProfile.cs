using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.data.models.profile;

public class UserProfile
{
  [Key, ForeignKey("User")]
  public int Id { get; set; }

  [MaxLength(30)]
  public string Nombre { get; set; } = string.Empty;

  [MaxLength(30)]
  public string Apellido { get; set; } = string.Empty;
  public DateTime FechaNacimiento { get; set; }
  public int Telf { get; set; }
  public int Ci { get; set; }
  [MaxLength(5)]
  public string ComplementoCi { get; set; } = string.Empty;
  
  [MaxLength(30)]
  public string Genero { get; set; } = string.Empty;

  [MaxLength(30)]
  public string Email { get; set; } = string.Empty;

  public User User { get; set; } = null!;
  public ScoutProfile? ScoutProfile { get; set; }
  public DiriProfile? DiriProfile { get; set; }
}
