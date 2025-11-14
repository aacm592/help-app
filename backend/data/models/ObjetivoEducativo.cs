using System.ComponentModel.DataAnnotations;

namespace backend.data.models;

public class ObjetivoEducativo
{
  public int Id { get; set; }

  [MaxLength(100)]
  public string Descripcion { get; set; } = string.Empty;

  public int AreaCrecimientoId { get; set; }
  public AreaCrecimiento AreaCrecimiento { get; set; } =  new AreaCrecimiento();

  public int EtapaProgresionId { get; set; }
  public EtapaProgresion EtapaProgresion { get; set; } =   new EtapaProgresion();
  
  public ICollection<ObjetivoUsuario> UsuariosObjetivo { get; set; } = new List<ObjetivoUsuario>();
}
