using System.ComponentModel.DataAnnotations;

namespace backend.data.models;

public class AreaCrecimiento
{
  public int Id { get; set; }
  
  [MaxLength(20)]
  public string Nombre { get; set; } = string.Empty;

  public ICollection<ObjetivoEducativo> ObjetivosEducativos { get; set; } = new List<ObjetivoEducativo>();
}
