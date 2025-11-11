namespace backend.data.models;

public class Rama
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public int EdadMinima { get; set; }
  public int EdadMaxima { get; set; }

  public ICollection<Unidad> Unidades { get; set; } = new List<Unidad>();
  public ICollection<EtapaProgresion> EtapasProgresion { get; set; } = new List<EtapaProgresion>();
}
