using AutoMapper;
using backend.data.models;
using backend.data.models.registros;
using backend.dtos.registros;
using backend.dtos.responses;
using backend.enums;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class DistritoService : IDistritoService
{
  private readonly IDistritoRepository _distritoRepository;
  private readonly IRegistroRepository _registroRepository;
  private readonly IGestionRepository _gestionRepository;
  private readonly IPermisoRepository _permisoRepository;
  private readonly IUserRepository _userRepository;
  private readonly IGrupoScoutRepository _grupoScoutRepository;
  private readonly IMapper _mapper;

  public DistritoService(IDistritoRepository distritoRepository, IMapper mapper, IRegistroRepository registroRepository, IGestionRepository gestionRepository, IPermisoRepository permisoRepository, IUserRepository userRepository, IGrupoScoutRepository grupoScoutRepository)
  {
    _distritoRepository = distritoRepository;
    _mapper = mapper;
    _registroRepository = registroRepository;
    _gestionRepository = gestionRepository;
    _permisoRepository = permisoRepository;
    _userRepository = userRepository;
    _grupoScoutRepository = grupoScoutRepository;
  }

  public async Task<IEnumerable<CatalogDto>> GetAllAsync()
  {
    var distritos = await _distritoRepository.GetAll();
    return _mapper.Map<IEnumerable<CatalogDto>>(distritos);
  }

  public async Task<IEnumerable<GroupRegistroResumen>> GetResumenRegistrosByDistritoId(int userId, List<RegistroStatus> status)
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
    
    var registros = await _registroRepository.GetRegistersByDistritoName(distrito.Nombre, gestion.Id, status);
    
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

  public async Task<UnidadRegistrosDto> GetRegistrosDistrito(int userId, List<RegistroStatus> status)
  {
    var (distrito, gestion) = await GetDistritoAndGestion(userId);
    var registros = (await _registroRepository.GetRegistersByDistritoName(distrito.Nombre, gestion.Id, status)).ToList();    
    return GetRegistrosDistrito(distrito, registros);
  }

  public async Task<IEnumerable<AdminInfoDto>> GetAdmins(int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null) throw new ApplicationException("Usuario no encontrado.");
    
    var permiso = user.UserPermisos.FirstOrDefault(x => x.PermisoId == 3);
    if (permiso == null || permiso.AreaId <= 0)
      throw new ApplicationException("El usuario no tiene permisos suficientes.");

    var gestion = await _gestionRepository.GetUltimaGestion();
    int gestionId = 0;
    if (gestion != null) gestionId = gestion.Id;

    var permissionList = new List<int> { 3, 4 };
    var allAdmins = await _userRepository.GetUsersByPermisoAndArea(permissionList.ToArray(), permiso.AreaId, gestionId);

    var tupleList = allAdmins!.Select(u => (user: u, permisos: permissionList));

    return _mapper.Map<IEnumerable<AdminInfoDto>>(tupleList);
  }
  
  public async Task<IEnumerable<AdminGrupoInfoDto>> GetResponsablesGrupo(int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null) 
        throw new KeyNotFoundException("Usuario no encontrado.");
    
    var permisoEjecutor = user.UserPermisos.FirstOrDefault(x => x.PermisoId == 3 || x.PermisoId == 4);
    if (permisoEjecutor == null || permisoEjecutor.AreaId <= 0)
        throw new UnauthorizedAccessException("Permisos insuficientes.");

    var gruposRaw = await _grupoScoutRepository.GetByDistritoIdAsync(permisoEjecutor.AreaId);
    var grupos = gruposRaw.ToList();

    if (!grupos.Any()) 
        return Enumerable.Empty<AdminGrupoInfoDto>();

    var gestion = await _gestionRepository.GetUltimaGestion();
    int gestionId = gestion?.Id ?? 0;

    var permissionList = new[] { 1 };
    var responsablesRaw = await _userRepository.GetUsersByPermiso(permissionList, gestionId);
    
    var todosLosResponsables = (responsablesRaw ?? Enumerable.Empty<User>()).ToList();

    var grupoIds = grupos.Select(g => g.Id).ToList();

    var responsablesLookup = todosLosResponsables
        .SelectMany(u => u.UserPermisos
            .Where(p => p.PermisoId == 1 && grupoIds.Contains(p.AreaId)), 
            (usuario, permiso) => new { permiso.AreaId, usuario })
        .ToLookup(x => x.AreaId, x => x.usuario);

    return grupos.Select(grupoScout => 
    {
        var responsable = responsablesLookup[grupoScout.Id].FirstOrDefault();

        return new AdminGrupoInfoDto()
        {
            Id = responsable?.Id ?? 0, 
            Nombre = responsable?.Profile != null 
                ? $"{responsable.Profile.Nombre} {responsable.Profile.Apellido}" 
                : "Sin responsable",
            Permiso = "Responsable de grupo",
            Grupo = grupoScout.Nombre,
            GrupoId = grupoScout.Id,
        };
    }).ToList();
  }

  private UnidadRegistrosDto GetRegistrosDistrito(Distrito distrito, List<Registro> registros)
  {
    var r = new UnidadRegistrosDto()
    {
      Id = distrito.Id,
      Nombre = distrito.Nombre,
      Dirigentes =
        _mapper.Map<List<UserRegistrosDto<DiriInfoDto>>>(registros.Where(x => x.RegistroDiri != null).ToList()),
      Scouts = _mapper.Map<List<UserRegistrosDto<ScoutInfoDto>>>(registros
        .Where(x => x.RegistroScout != null && x.RegistroDiri == null).ToList()),
    };
    
    return r;
  }

  private async Task<(Distrito distrito, Gestion gestion)> GetDistritoAndGestion(int userId)
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

    return (distrito, gestion);
  }
}
