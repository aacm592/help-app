using System.ComponentModel.DataAnnotations;

namespace backend.data.models;

public class GrupoScout
{
  public int Id { get; set; }

  [MaxLength(50)]
  public string Nombre { get; set; } = string.Empty;

  public int DistritoId { get; set; }
  public Distrito Distrito { get; set; } = null!;

  public ICollection<Unidad> Unidades { get; set; } = new List<Unidad>();
}
