namespace backend.data.models;

public class Unidad
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public string Codigo { get; set; }

  public int GrupoScoutId { get; set; }
  public GrupoScout GrupoScout { get; set; }

  public int RamaId { get; set; }
  public Rama Rama { get; set; }

  public ICollection<User> Usuarios { get; set; } = new List<User>();
}
