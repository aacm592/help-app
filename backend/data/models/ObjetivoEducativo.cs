namespace backend.data.models;

public class ObjetivoEducativo
{
  public int Id { get; set; }
  public string Descripcion { get; set; }

  public int AreaId { get; set; }
  public AreaCrecimiento AreaCrecimiento { get; set; }

  public int EtapaId { get; set; }
  public EtapaProgresion EtapaProgresion { get; set; }
    
  public ICollection<User> Usuarios { get; set; } = new List<User>();
}
