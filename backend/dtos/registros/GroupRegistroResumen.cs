using backend.data.models.registros;

namespace backend.dtos.registros;

public class GroupRegistroResumen
{
  public string Grupo { get; set; } = string.Empty;
  public int Lobatos {get; set;}
  public int Explos {get; set;}
  public int Pios {get; set;}
  public int Rovers {get; set;}
  public int Diris {get; set;}
  public List<RegistroDto> Registros { get; set; } = new List<RegistroDto>();
}
