namespace backend.data.models.registros;

public class Gestion
{
  public int Id { get; set; }
  public int Year { get; set; }
  public bool Active { get; set; }
  
  public ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
