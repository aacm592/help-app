using System.ComponentModel.DataAnnotations;

namespace backend.data.models;

public class User
{
  public int Id { get; set; }

  [MaxLength(60)]
  public string Nombre { get; set; } = string.Empty;
  public DateTime FechaNacimiento { get; set; }
  
  [MaxLength(50)]
  public string NombreUsuario { get; set; } = string.Empty;

  [MaxLength(50)]
  public string Contrasena { get; set; } = string.Empty;

  public int TipoId { get; set; }
  public Tipo Tipo { get; set; } =  null!;

  public ICollection<Unidad> Unidades { get; set; } = new List<Unidad>();
  public ICollection<ObjetivoUsuario> ObjetivosUsuario { get; set; } = new List<ObjetivoUsuario>();
}
