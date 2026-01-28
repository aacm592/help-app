using backend.data.models;
using backend.data.models.registros;
using backend.enums;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class RegistroService : IRegistroService
{
  private readonly IRegistroRepository _registroRepository;
  private readonly IGestionRepository _gestiónRepository;
  private readonly IUserRepository _userRepository;
  private readonly IGrupoScoutRepository _grupoScoutRepository;
  private readonly IProfileRepository _profileRepository;

  public RegistroService(IRegistroRepository registroRepository, IGestionRepository gestiónRepository,
    IUserRepository userRepository, IGrupoScoutRepository grupoScoutRepository, IProfileRepository profileRepository)
  {
    _registroRepository = registroRepository;
    _gestiónRepository = gestiónRepository;
    _userRepository = userRepository;
    _grupoScoutRepository = grupoScoutRepository;
    _profileRepository = profileRepository;
  }

  public async Task RegisterUserToGroup(int scoutId, int diriId)
  {
    var gestion = await GetGestion();

    var diri = await _userRepository.GetByIdWithTipoAndUnidadesAsync(diriId);
    if (diri == null)
      throw new ApplicationException("Usuario no encontrado");
    
    var permisoDiri = diri.UserPermisos.FirstOrDefault(p => p.PermisoId == 1 || p.PermisoId == 2);
    
    if (permisoDiri == null)
      throw new ApplicationException("No tienes permisos para registrar usuarios a un grupo scout");

    var grupo = await _grupoScoutRepository.GetById(permisoDiri.AreaId);
    if (grupo == null)
      throw new ApplicationException("Grupo no encontrado");
    
    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(scoutId);
    if (scout == null)
      throw new ApplicationException("El scout no existe");

    VerifyScoutsOnTheSameGroup(scout, diri);

    var registro = new Registro()
    {
      GestionId = gestion.Id,
      UserId = scout.Id,
      Ci = scout.Profile!.Ci,
      Nombre = scout.Profile.Nombre + scout.Profile.Apellido,
      Distrito = grupo.Distrito.Nombre,
      FechaNacimiento = scout.Profile.FechaNacimiento,
      Genero = scout.Profile.Genero,
      RegistroGrupo = DateTime.UtcNow,
      Unidad = String.Join("/", scout.Unidades.Select(u => u.Nombre)),
      Rama = scout.TipoId == 1 ? scout.Unidades.FirstOrDefault()!.Rama.Nombre : "Dirigente",
      Grupo = grupo.Nombre,
      Status = RegistroStatus.RegistroGrupo,
    };

    switch (scout.TipoId)
    {
      case 1:
        var ps = await _profileRepository.GetScoutProfile(scoutId);
        registro.RegistroScout = new RegistroScout()
        {
          Curso = ps!.ScoutProfile!.Curso,
          Etapa = ps!.ScoutProfile.Etapa,
          UnidadEducativa = ps!.ScoutProfile.UnidadEducativa,
        };
        break;
      case 2:
        var pd = await _profileRepository.GetDiriProfile(scoutId);
        registro.RegistroDiri = new RegistroDiri()
        {
          Cargo1 = pd!.DiriProfile!.Cargo1,
          Cargo2 = pd.DiriProfile.Cargo2,
          Ocupacion = pd.DiriProfile.Ocupacion,
          Profesion = pd.DiriProfile.Profesion,
        };
        break;
    }

    await _registroRepository.Create(registro);
  }

  public async Task CancelRegisterToGroup(int scoutId, int diriId)
  {
    var gestion = GetGestion();
    
    var diri = await _userRepository.GetByIdWithTipoAndUnidadesAsync(diriId);
    if (diri == null)
      throw new ApplicationException("Usuario no encontrado");
    
    var permisoDiri = diri.UserPermisos.FirstOrDefault(p => p.PermisoId == 1 || p.PermisoId == 2);
    
    if (permisoDiri == null)
      throw new ApplicationException("No tienes permisos para registrar usuarios a un grupo scout");

    var grupo = await _grupoScoutRepository.GetById(permisoDiri.AreaId);
    if (grupo == null)
      throw new ApplicationException("Grupo no encontrado");
    
    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(scoutId);
    if (scout == null)
      throw new ApplicationException("El scout no existe");
    
    var registro = await _registroRepository.GetRegistroByUserId(scoutId, gestion.Id);
    if (registro == null)
      throw new ApplicationException("Registro no encontrado");
    
    if (registro.Status != RegistroStatus.RegistroGrupo)
      throw new ApplicationException("No se puede cancelar el registro");
    
    await _registroRepository.Delete(registro);
  }

  private async Task<Gestion> GetGestion()
  {
    var gestion = await _gestiónRepository.GetGestionActual();
    if (gestion == null)
      throw new ApplicationException("No hay una gestión activa actualmente");
    return gestion;
  }

  private void VerifyScoutsOnTheSameGroup(User scout, User diri)
  {
    var permisoScout = scout.UserPermisos.FirstOrDefault(p => p.PermisoId == 1 || p.PermisoId == 2);
    var permisoDiri = diri.UserPermisos.FirstOrDefault(p => p.PermisoId == 1 || p.PermisoId == 2);

    switch (permisoScout)
    {
      case null:
        if (scout.Unidades.Count > 1 && !scout.Unidades.Any(u => u.GrupoScoutId == permisoDiri!.AreaId))
          throw new ApplicationException("No estás en el mismo grupo que el scout");
        break;
      default:
        if(permisoScout.AreaId != permisoDiri!.AreaId)
          throw new ApplicationException("No estás en el mismo grupo que el scout");
        break;
    }
  }
  
}
