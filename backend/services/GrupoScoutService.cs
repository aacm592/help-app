using AutoMapper;
using backend.dtos.registros;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class GrupoScoutService : IGrupoScoutService
{
  private readonly IGrupoScoutRepository _grupoScoutRepository;
  private readonly IUserRepository _userRepository;
  private readonly IGestionRepository _gestionRepository;
  private readonly IMapper _mapper;

  public GrupoScoutService(IGrupoScoutRepository grupoScoutRepository, IMapper mapper, IUserRepository userRepository, IGestionRepository gestionRepository)
  {
    _grupoScoutRepository = grupoScoutRepository;
    _mapper = mapper;
    _userRepository = userRepository;
    _gestionRepository = gestionRepository;
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

  public async Task<IEnumerable<GrupoUnidadesResponseDto>> UsersById(int userId)
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

    var grupo = await _grupoScoutRepository.GetByIdWithUsers(permiso.AreaId, gestion!.Id);
  
    if (grupo == null)
      throw new ApplicationException("El grupo asignado al usuario no existe en la base de datos.");
  
    return _mapper.Map<List<GrupoUnidadesResponseDto>>(grupo.Unidades.ToList());
  }

  public async Task<IEnumerable<GrupoUnidadesResponseDto>> GetUsersByRamaId(int userId, int ramaId)
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

    var grupo = await _grupoScoutRepository.GetByRamaWithUsers(permiso.AreaId, gestion!.Id, ramaId);
  
    if (grupo == null)
      throw new ApplicationException("El grupo asignado al usuario no existe en la base de datos.");
    
    return _mapper.Map<List<GrupoUnidadesResponseDto>>(grupo.Unidades.ToList());
  }
}
