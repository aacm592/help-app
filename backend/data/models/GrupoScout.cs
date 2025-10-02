namespace backend.data.models;

public class GrupoScout
{
  public int Id { get; set; }
  public string Nombre { get; set; }

  public int DistritoId { get; set; }
  public Distrito Distrito { get; set; }

  public ICollection<Unidad> Unidades { get; set; } = new List<Unidad>();
}
