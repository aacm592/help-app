namespace backend.data.models;

public class UserPermiso
{
  public int UserId { get; set; }
  public User User { get; set; } = null!;

  public int PermisoId { get; set; }
  public Permiso Permiso { get; set; } = null!;

  public int? GrupoScoutId { get; set; }
  public GrupoScout? GrupoScout { get; set; }

  public int? DistritoId { get; set; }
  public Distrito? Distrito { get; set; }
}