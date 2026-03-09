using backend.data.models;
using backend.data.models.registros;
using backend.dtos.auth;
using backend.dtos.registros;
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
  private readonly IPermisoRepository _permisoRepository;

  public RegistroService(IRegistroRepository registroRepository, IGestionRepository gestiónRepository,
    IUserRepository userRepository, IGrupoScoutRepository grupoScoutRepository, IProfileRepository profileRepository, IPermisoRepository permisoRepository)
  {
    _registroRepository = registroRepository;
    _gestiónRepository = gestiónRepository;
    _userRepository = userRepository;
    _grupoScoutRepository = grupoScoutRepository;
    _profileRepository = profileRepository;
    _permisoRepository = permisoRepository;
  }

  public async Task RegisterUserToGroup(IdDto scoutId, int diriId)
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
    
    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(scoutId.Id);
    if (scout == null)
      throw new ApplicationException("El scout no existe");

    VerifyScoutsOnTheSameGroup(scout, diri);
    VerifyScoutHasFullProfile(scout);
    
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
        var ps = await _profileRepository.GetScoutProfile(scoutId.Id);
        registro.RegistroScout = new RegistroScout()
        {
          Curso = ps!.ScoutProfile!.Curso,
          Etapa = ps!.ScoutProfile.Etapa,
          UnidadEducativa = ps!.ScoutProfile.UnidadEducativa,
        };
        break;
      case 2:
        var pd = await _profileRepository.GetDiriProfile(scoutId.Id);
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
    
    var registro = await _registroRepository.GetRegistroByUserId(scoutId, gestion.Id);
    if (registro == null)
      throw new ApplicationException("Registro no encontrado");
    
    if (registro.Status != RegistroStatus.RegistroGrupo)
      throw new ApplicationException("No se puede cancelar el registro");
    
    await _registroRepository.Delete(registro);
  }

  public async Task SendRegistersToDistrito(IEnumerable<RegistroDto> users, int userId)
  {
    var permisos = await _permisoRepository.GetPermisosByUserId(userId);
    var p = permisos.FirstOrDefault(x => x.PermisoId == 1 || x.PermisoId == 2);
    if (p == null)
      throw new ApplicationException("No tienes los permisos necesarios");
    
    await ActualizarStatus(users.ToList(), RegistroStatus.EnviadoDistrito);
  }
  
  private async Task ActualizarStatus(IEnumerable<RegistroDto> registrosDtos, RegistroStatus nuevoStatus)
  {
    var gestion = await GetGestion();
    
    var listaDtos = registrosDtos.ToList(); 
    if (!listaDtos.Any()) return;

    var userIds = listaDtos.Select(d => d.UserId).Distinct().ToList();
    
    var registrosDb = await _registroRepository.GetMany(userIds, gestion.Id);

    Console.WriteLine(registrosDb.Count);
    if (!registrosDb.Any())
      throw new ApplicationException("No se encontraron registros para actualizar en la base de datos.");
    
    foreach (var registro in registrosDb)
    {
      registro.Status = nuevoStatus;
      SetStatusTimestamps(registro, nuevoStatus);
    }
    await _registroRepository.Update();
  }

  private void SetStatusTimestamps(Registro registro, RegistroStatus status)
  {
    var now = DateTime.UtcNow;
    switch (status)
    {
      case RegistroStatus.EnviadoDistrito: registro.EnvioDistrito = now; break;
      case RegistroStatus.RegistroDistrito: registro.RegistroDistrito = now; break;
      case RegistroStatus.EnviadoNacional: registro.EnvioNacional = now; break;
      case RegistroStatus.RegistroNacional: registro.RegistroNacional = now; break;
    }
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

  private void VerifyScoutHasFullProfile(User scout)
  {
    var perfil = scout.Profile;

    if (perfil == null)
      throw new ApplicationException("El usuario no tiene un perfil creado.");

    if (string.IsNullOrWhiteSpace(perfil.Nombre) || 
        string.IsNullOrWhiteSpace(perfil.Apellido) ||
        string.IsNullOrWhiteSpace(perfil.Genero) ||
        perfil.Ci == 0 || 
        perfil.FechaNacimiento == default)
    {
      throw new ApplicationException("El perfil base del usuario está incompleto (Nombre, Apellido, CI, Género o Fecha de Nacimiento).");
    }

    switch (scout.TipoId)
    {
      case 1:
        var sp = perfil.ScoutProfile;
        if (sp == null || 
            string.IsNullOrWhiteSpace(sp.UnidadEducativa) || 
            string.IsNullOrWhiteSpace(sp.Curso) || 
            string.IsNullOrWhiteSpace(sp.Etapa))
        {
          throw new ApplicationException("El perfil de Scout está incompleto (Unidad Educativa, Curso o Etapa).");
        }
        break;

      case 2:
        var dp = perfil.DiriProfile;
        if (dp == null || 
            string.IsNullOrWhiteSpace(dp.Profesion) || 
            string.IsNullOrWhiteSpace(dp.Ocupacion) || 
            string.IsNullOrWhiteSpace(dp.Cargo1))
        {
          throw new ApplicationException("El perfil de Dirigente está incompleto (Profesión, Ocupación o Cargo).");
        }
        break;
            
      default:
        throw new ApplicationException("Tipo de usuario no reconocido para validación de perfil.");
    }
  }
  
}
