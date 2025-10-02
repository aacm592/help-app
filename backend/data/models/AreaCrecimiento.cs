namespace backend.data.models;

public class AreaCrecimiento
{
  public int Id { get; set; }
  public string Nombre { get; set; }

  public ICollection<ObjetivoEducativo> ObjetivosEducativos { get; set; } = new List<ObjetivoEducativo>();
}
