using System.ComponentModel.DataAnnotations;
using backend.enums;

namespace backend.data.models.registros;

public class Registro
{
  public int GestionId { get; set; }
  public Gestion Gestion { get; set; } = null!;
  
  public int UserId { get; set; }
  public User User { get; set; } = null!;
  
  public DateTime EnvioNacional { get; set; }
  public DateTime RegistroNacional { get; set; }
  
  public DateTime EnvioDistrito { get; set; }
  public DateTime RegistroDistrito { get; set; }
  
  public DateTime RegistroGrupo { get; set; }
  
  public RegistroStatus Status { get; set; }

  [MaxLength(25)] public string Distrito { get; set; } = string.Empty;
  [MaxLength(50)] public string Grupo { get; set; } = string.Empty;
  [MaxLength(60)] public string Unidad { get; set; } = string.Empty;
  [MaxLength(20)] public string Rama { get; set; } = string.Empty;
  [MaxLength(60)] public string Nombre { get; set; } = string.Empty;
  [MaxLength(30)] public string Genero { get; set; } = string.Empty;
  public int Ci { get; set; }
  public DateTime FechaNacimiento { get; set; }
  
  public RegistroScout? RegistroScout { get; set; }
  public RegistroDiri?  RegistroDiri { get; set; }
}
