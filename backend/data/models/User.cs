namespace backend.data.models;

public class User
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public DateTime FechaNacimiento { get; set; }
  public string NombreUsuario { get; set; }
  public string Contrasena { get; set; }

  public int TipoId { get; set; }
  public Tipo Tipo { get; set; }

  public ICollection<Unidad> Unidades { get; set; } = new List<Unidad>();
  public ICollection<ObjetivoEducativo> ObjetivosEducativos { get; set; } = new List<ObjetivoEducativo>();
}
