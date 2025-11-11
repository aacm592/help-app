namespace backend.data.models;

public class EtapaProgresion
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  
  public int RamaId { get; set; }
  public Rama Rama { get; set; }


  public ICollection<ObjetivoEducativo> ObjetivosEducativos { get; set; } = new List<ObjetivoEducativo>();
}
