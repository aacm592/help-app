namespace backend.data.models;

public class Permiso
{
  public int Id { get; set; }
  public string Nombre { get; set; }

  public ICollection<Tipo> Tipos { get; set; } = new List<Tipo>();
}
