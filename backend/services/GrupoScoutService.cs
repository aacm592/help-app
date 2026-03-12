using AutoMapper;
using backend.dtos.registros;
using backend.dtos.responses;
using backend.enums;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class GrupoScoutService : IGrupoScoutService
{
  private readonly IGrupoScoutRepository _grupoScoutRepository;
  private readonly IUserRepository _userRepository;
  private readonly IGestionRepository _gestionRepository;
  private readonly IRegistroRepository _registroRepository;
  private readonly IPermisoRepository _permisoRepository;
  private readonly IMapper _mapper;

  public GrupoScoutService(IGrupoScoutRepository grupoScoutRepository, IMapper mapper, IUserRepository userRepository, IGestionRepository gestionRepository, IRegistroRepository registroRepository, IPermisoRepository permisoRepository)
  {
    _grupoScoutRepository = grupoScoutRepository;
    _mapper = mapper;
    _userRepository = userRepository;
    _gestionRepository = gestionRepository;
    _registroRepository = registroRepository;
    _permisoRepository = permisoRepository;
  }

  public async Task<IEnumerable<CatalogDto>> GetAllAsync()
  {
    var grupos = await _grupoScoutRepository.GetAll();
    return _mapper.Map<IEnumerable<CatalogDto>>(grupos);
  }
  
  public async Task<IEnumerable<CatalogDto>> GetByDistritoIdAsync(int distritoId)
  {
    var grupos = await _grupoScoutRepository.GetByDistritoIdAsync(distritoId);
    return _mapper.Map<IEnumerable<CatalogDto>>(grupos);
  }

  public async Task<IEnumerable<UnidadUsersDto>> UsersById(int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");

    var permiso = user.UserPermisos.FirstOrDefault(x => x.PermisoId == 1 || x.PermisoId == 2);
  
    if (permiso == null)
      throw new ApplicationException("El usuario no tiene el permiso de responsable de grupo.");

    if (permiso.AreaId <= 0)
      throw new ApplicationException("El usuario no tiene un ID de grupo válido asignado.");

    var gestion = await _gestionRepository.GetUltimaGestion();
    int gestionId = 0;
    if (gestion != null) gestionId = gestion.Id;
    
    var grupo = await _grupoScoutRepository.GetByIdWithUsers(permiso.AreaId, gestionId);
  
    if (grupo == null)
      throw new ApplicationException("El grupo asignado al usuario no existe en la base de datos.");
  
    return _mapper.Map<List<UnidadUsersDto>>(grupo.Unidades.ToList());
  }

  public async Task<IEnumerable<UnidadUsersDto>> GetUsersByRamaId(int userId, int ramaId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");

    var permiso = user.UserPermisos.FirstOrDefault(x => x.PermisoId == 1 || x.PermisoId == 2);
  
    if (permiso == null)
      throw new ApplicationException("El usuario no tiene el permiso de responsable de grupo.");

    if (permiso.AreaId <= 0)
      throw new ApplicationException("El usuario no tiene un ID de grupo válido asignado.");

    var gestion = await _gestionRepository.GetUltimaGestion();
    int gestionId = 0;
    if (gestion != null) gestionId = gestion.Id;
    
    var grupo = await _grupoScoutRepository.GetByRamaWithUsers(permiso.AreaId, gestionId, ramaId);
  
    if (grupo == null)
      throw new ApplicationException("El grupo asignado al usuario no existe en la base de datos.");
    
    return _mapper.Map<List<UnidadUsersDto>>(grupo.Unidades.ToList());
  }

  public async Task<IEnumerable<UnidadRegistrosDto>> GetRegistros(int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");

    var permiso = user.UserPermisos.FirstOrDefault(x => x.PermisoId == 1 || x.PermisoId == 2);
  
    if (permiso == null)
      throw new ApplicationException("El usuario no tiene el permiso de responsable de grupo.");

    if (permiso.AreaId <= 0)
      throw new ApplicationException("El usuario no tiene un ID de grupo válido asignado.");

    var gestion = await _gestionRepository.GetUltimaGestion();

    var grupo = await _registroRepository.GetGroupRegisters(permiso.AreaId, gestion!.Id);
  
    if (grupo == null)
      throw new ApplicationException("El grupo asignado al usuario no existe en la base de datos.");
  
    return _mapper.Map<List<UnidadRegistrosDto>>(grupo.Unidades.ToList());  
  }

  public async Task<IEnumerable<UnidadRegistrosDto>> GetRegistrosByRama(int userId, int ramaId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");

    var permiso = user.UserPermisos.FirstOrDefault(x => x.PermisoId == 1 || x.PermisoId == 2);
  
    if (permiso == null)
      throw new ApplicationException("El usuario no tiene el permiso de responsable de grupo.");

    if (permiso.AreaId <= 0)
      throw new ApplicationException("El usuario no tiene un ID de grupo válido asignado.");

    var gestion = await _gestionRepository.GetUltimaGestion();

    var grupo = await _registroRepository.GetGroupRegistersByRama(permiso.AreaId, gestion!.Id, ramaId);
  
    if (grupo == null)
      throw new ApplicationException("El grupo asignado al usuario no existe en la base de datos.");
    
    return _mapper.Map<List<UnidadRegistrosDto>>(grupo.Unidades.ToList());  
  }
  
  public async Task<IEnumerable<UnidadResumenDto>> GetUnidadesResumenByGrupo(int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null) throw new ApplicationException("Usuario no encontrado.");

    var permiso = user.UserPermisos.FirstOrDefault(x => x.PermisoId == 1 || x.PermisoId == 2);
    if (permiso == null || permiso.AreaId <= 0)
      throw new ApplicationException("El usuario no tiene un grupo asignado o permisos suficientes.");

    var gestion = await _gestionRepository.GetUltimaGestion();
    if (gestion == null) throw new ApplicationException("No hay una gestión activa configurada.");

    var grupo = await _grupoScoutRepository.GetByIdWithUsers(permiso.AreaId, gestion.Id);
    if (grupo == null) throw new ApplicationException("Grupo no encontrado.");

    var unidadesResumen = grupo.Unidades.Select(u => new UnidadResumenDto
    {
      Id = u.Id,
      Nombre = u.Nombre,
      Total = u.Usuarios.Count,
      Registrados = u.Usuarios.Count(usr => usr.Registros.Any(r => r.GestionId == gestion.Id))
    });

    return unidadesResumen;
  }

  public async Task<IEnumerable<UserDataDto<DiriInfoDto>>> GetAdmins(int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null) throw new ApplicationException("Usuario no encontrado.");
    
    var permiso = user.UserPermisos.FirstOrDefault(x => x.PermisoId == 1 || x.PermisoId == 2);
    if (permiso == null || permiso.AreaId <= 0)
      throw new ApplicationException("El usuario no tiene un grupo asignado o permisos suficientes.");
    var gestion = await _gestionRepository.GetUltimaGestion();
    int gestionId = 0;
    if (gestion != null) gestionId = gestion.Id;

    var allAdmins = await _userRepository.GetUsersByPermisoAndArea(new[] { 1, 2 }, permiso.AreaId, gestionId);
    
    return _mapper.Map<List<UserDataDto<DiriInfoDto>>>(allAdmins);  
  }
  
  public async Task<IEnumerable<UserRegistrosDto<DiriInfoDto>>> GetAdminsRegisters(int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null) throw new ApplicationException("Usuario no encontrado.");
    
    var permiso = user.UserPermisos.FirstOrDefault(x => x.PermisoId == 1 || x.PermisoId == 2);
    if (permiso == null || permiso.AreaId <= 0)
      throw new ApplicationException("El usuario no tiene un grupo asignado o permisos suficientes.");
    
    var gestion = await _gestionRepository.GetUltimaGestion();
    if (gestion == null) throw new ApplicationException("No hay una gestión activa configurada.");

    var allAdmins = await _registroRepository.GetRegistersByPermisoAndArea(new[] { 1, 2 }, permiso.AreaId, gestion.Id);
    
    return _mapper.Map<List<UserRegistrosDto<DiriInfoDto>>>(allAdmins);  
  }

  public async Task<ResumenRegistrosDto> GetResumenRegistros(int userId)
  {
    var gestion = await _gestionRepository.GetGestionActual();
    if (gestion == null)
      throw new Exception("No hay gestión actual");

    var permisos = await _permisoRepository.GetPermisosByUserId(userId);
    var p = permisos.FirstOrDefault(x => x.PermisoId == 1 || x.PermisoId == 2); 
    if (p == null)
      throw new Exception("No tienes los permisos suficientes");

    var grupo = await _grupoScoutRepository.GetById(p.AreaId);
    if (grupo == null)
      throw new Exception("El grupo no existe");

    var registrosEnumerable = await _registroRepository.GetRegistersByDistritoAndGrupoName(grupo.Distrito.Nombre, grupo.Nombre, gestion.Id);
    var registros = registrosEnumerable.ToList();
    
    var resumen = new ResumenRegistrosDto
    {
      Lobatos = registros.Count(r => r.Rama == "Lobatos"),
      Explos = registros.Count(r => r.Rama == "Exploradores"),
      Pios = registros.Count(r => r.Rama == "Pioneros"),
      Rovers = registros.Count(r => r.Rama == "Rovers"),
      Diris = registros.Count(r => r.RegistroDiri != null),
        
      RegistroGrupo = registros.Count(r => r.Status == RegistroStatus.RegistroGrupo),
      EnviadosDistrito = registros.Count(r => r.Status == RegistroStatus.EnviadoDistrito),
      RegistroDistrito = registros.Count(r => r.Status == RegistroStatus.RegistroDistrito),
      EnviadosNacional = registros.Count(r => r.Status == RegistroStatus.EnviadoNacional),
      RegistroNacional = registros.Count(r => r.Status == RegistroStatus.RegistroNacional),
      RegistrosGrupo = _mapper.Map<List<RegistroDto>>(registros.Where(x => x.Status == RegistroStatus.RegistroGrupo).ToList())
    };

    return resumen;
  }
}
