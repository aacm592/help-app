using System.ComponentModel.DataAnnotations;

namespace backend.data.models;

public class Permiso
{
  public int Id { get; set; }
  
  [MaxLength(50)]
  public string Nombre { get; set; }  = string.Empty;

  public ICollection<User> Users { get; set; } = new List<User>();
}
