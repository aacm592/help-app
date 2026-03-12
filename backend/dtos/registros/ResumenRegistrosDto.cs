namespace backend.dtos.registros;

public class ResumenRegistrosDto
{
  public int Lobatos {get; set;}
  public int Explos {get; set;}
  public int Pios {get; set;}
  public int Rovers {get; set;}
  public int Diris {get; set;}
  public int RegistroGrupo {get; set;}
  public int EnviadosDistrito {get; set;}
  public int RegistroDistrito {get; set;}
  public int EnviadosNacional {get; set;}
  public int RegistroNacional {get; set;}
  public List<RegistroDto> RegistrosGrupo { get; set; } = new List<RegistroDto>();
}
