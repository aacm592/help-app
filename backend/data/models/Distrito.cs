namespace backend.data.models;

public class Distrito
{
  public int Id { get; set; }
  public string Nombre { get; set; }
    
  public ICollection<GrupoScout> GruposScout { get; set; } = new List<GrupoScout>();
}
