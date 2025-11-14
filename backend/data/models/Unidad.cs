using System.ComponentModel.DataAnnotations;

namespace backend.data.models;

public class Unidad
{
  public int Id { get; set; }

  [MaxLength(60)]
  public string Nombre { get; set; } = string.Empty;
  
  [MaxLength(10)]
  public string Codigo { get; set; } = string.Empty;

  public int GrupoScoutId { get; set; }
  public GrupoScout GrupoScout { get; set; } =  new GrupoScout();

  public int RamaId { get; set; }
  public Rama Rama { get; set; } =   new Rama();

  public ICollection<User> Usuarios { get; set; } = new List<User>();
}
