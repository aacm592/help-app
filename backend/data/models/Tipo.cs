using System.ComponentModel.DataAnnotations;

namespace backend.data.models;

public class Tipo
{
  public int Id { get; set; }

  [MaxLength(50)]
  public string Nombre { get; set; } = string.Empty;

  public ICollection<User> Usuarios { get; set; } = new List<User>();

  public ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
