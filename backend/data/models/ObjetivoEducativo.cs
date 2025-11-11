namespace backend.data.models;

public class ObjetivoEducativo
{
  public int Id { get; set; }
  public string Descripcion { get; set; }

  public int AreaCrecimientoId { get; set; }
  public AreaCrecimiento AreaCrecimiento { get; set; }

  public int EtapaProgresionId { get; set; }
  public EtapaProgresion EtapaProgresion { get; set; }
  
  public ICollection<ObjetivoUsuario> UsuariosObjetivo { get; set; } = new List<ObjetivoUsuario>();
}
