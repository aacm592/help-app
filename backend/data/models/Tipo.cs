namespace backend.data.models;

public class Tipo
{
  public int Id { get; set; }
  public string Nombre { get; set; }

  public ICollection<User> Usuarios { get; set; } = new List<User>();

  public ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
