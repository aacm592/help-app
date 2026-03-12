using AutoMapper;
using backend.dtos.registros;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class DistritoService : IDistritoService
{
  private readonly IDistritoRepository _distritoRepository;
  private readonly IRegistroRepository _registroRepository;
  private readonly IGestionRepository _gestionRepository;
  private readonly IPermisoRepository _permisoRepository;
  private readonly IMapper _mapper;

  public DistritoService(IDistritoRepository distritoRepository, IMapper mapper, IRegistroRepository registroRepository, IGestionRepository gestionRepository, IPermisoRepository permisoRepository)
  {
    _distritoRepository = distritoRepository;
    _mapper = mapper;
    _registroRepository = registroRepository;
    _gestionRepository = gestionRepository;
    _permisoRepository = permisoRepository;
  }

  public async Task<IEnumerable<CatalogDto>> GetAllAsync()
  {
    var distritos = await _distritoRepository.GetAll();
    return _mapper.Map<IEnumerable<CatalogDto>>(distritos);
  }

  public async Task<IEnumerable<GroupRegistroResumen>> GetResumenRegistrosByDistritoId(int userId)
  {
    var gestion = await _gestionRepository.GetGestionActual();
    
    if (gestion == null)
      throw new Exception("No hay gestión actual");
    
    var permisos = await _permisoRepository.GetPermisosByUserId(userId);
    var p = permisos.FirstOrDefault(x => x.PermisoId == 3 || x.PermisoId == 4);
    if (p == null)
      throw new Exception("No tienes los permisos suficientes");
    
    var distrito = await _distritoRepository.GetDistritoById(p.AreaId);
    if (distrito == null)
      throw new Exception("El distrito no existe");
    
    var registros = await _registroRepository.GetRegistersByDistritoName(distrito.Nombre, gestion.Id);
    
    var resumen = registros
      .GroupBy(r => r.Grupo)
      .Select(g => new GroupRegistroResumen
      {
        Grupo = g.Key,
        Lobatos = g.Count(r => r.Rama == "Lobatos"),
        Explos = g.Count(r => r.Rama == "Exploradores"),
        Pios = g.Count(r => r.Rama == "Pioneros"),
        Rovers = g.Count(r => r.Rama == "Rovers"),
        Diris = g.Count(r => r.RegistroDiri != null),
        Registros = _mapper.Map<List<RegistroDto>>(g.ToList())
      })
      .ToList();
    return resumen;
  }
}
