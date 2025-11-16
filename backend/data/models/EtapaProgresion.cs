using System.ComponentModel.DataAnnotations;

namespace backend.data.models;

public class EtapaProgresion
{
  public int Id { get; set; }

  [MaxLength(30)]
  public string Nombre { get; set; } = string.Empty;
  
  public int RamaId { get; set; }
  public Rama Rama { get; set; }=  null!;


  public ICollection<ObjetivoEducativo> ObjetivosEducativos { get; set; } = new List<ObjetivoEducativo>();
}
