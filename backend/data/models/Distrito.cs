using System.ComponentModel.DataAnnotations;

namespace backend.data.models;

public class Distrito
{
  public int Id { get; set; }

  [MaxLength(25)]
  public string Nombre { get; set; } =  string.Empty;
    
  public ICollection<GrupoScout> GruposScout { get; set; } = new List<GrupoScout>();
}
