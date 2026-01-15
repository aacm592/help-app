using System.ComponentModel.DataAnnotations;
using backend.data.models.especialidades;
using backend.data.models.profile;

namespace backend.data.models;

public class User
{
  public int Id { get; set; }

  [MaxLength(50)] public string NombreUsuario { get; set; } = string.Empty;

  [MaxLength(80)] public string Contrasena { get; set; } = string.Empty;

  public int TipoId { get; set; }
  public Tipo Tipo { get; set; } = null!;

  public ICollection<Unidad> Unidades { get; set; } = new List<Unidad>();
  public ICollection<ObjetivoUsuario> ObjetivosUsuario { get; set; } = new List<ObjetivoUsuario>();
  
  public ICollection<RequisitoEspUser> RequisitoEspUser { get; set; } = new List<RequisitoEspUser>();

  public ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

  [MaxLength(10)]
  public string? PasswordResetToken { get; set; }

  public DateTime? PasswordResetTokenExpiry { get; set; }
  
  public UserProfile? Profile { get; set; }
}
