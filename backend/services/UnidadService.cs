using System.Security.Cryptography;
using AutoMapper;
using backend.data.models;
using backend.dtos.request;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class UnidadService : IUnidadService
{
  private readonly IUnidadRepository _unidadRepository;
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;

  private static readonly char[] CodigoChars =
    "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ123456789".ToCharArray();

  public UnidadService(
    IUnidadRepository unidadRepository,
    IUserRepository userRepository,
    IMapper mapper)
  {
    _unidadRepository = unidadRepository;
    _userRepository = userRepository;
    _mapper = mapper;
  }

  public async Task<UnidadResponseDto> Create(CreateUnidadDto dto, int creadorId)
  {
    var creador = await GetUserOrThrowAsync(creadorId);
    EnsureDirigente(creador);
    EnsureSameGrupoIfAlreadyInUnit(creador, dto.GrupoScoutId);

    var codigo = await GenerateUniqueCodigoAsync();

    var nuevaUnidad = new Unidad
    {
      Nombre = dto.Nombre,
      GrupoScoutId = dto.GrupoScoutId,
      RamaId = dto.RamaId,
      Codigo = codigo,
      Usuarios = new List<User> { creador }
    };

    var unidadGuardada = await _unidadRepository.Add(nuevaUnidad);
    return _mapper.Map<UnidadResponseDto>(unidadGuardada);
  }

  public async Task<UnidadResponseDto> JoinUnidad(string codigo, int userId)
  {
    var unidad = await _unidadRepository.GetByCodigoAsync(codigo);
    if (unidad == null)
      throw new ApplicationException("Unidad no encontrada con ese código.");

    var user = await GetUserOrThrowAsync(userId);
    EnsureUserCanJoinUnidad(user, unidad);

    unidad.Usuarios.Add(user);
    await _unidadRepository.UpdateAsync(unidad);

    return _mapper.Map<UnidadResponseDto>(unidad);
  }

  private async Task<User> GetUserOrThrowAsync(int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");
    return user;
  }

  private static void EnsureDirigente(User user)
  {
    if (user.Tipo?.Nombre != "Dirigente")
      throw new ApplicationException("Solo los Dirigentes tienen permiso para crear unidades.");
  }
  
  private static void EnsureSameGrupoIfAlreadyInUnit(User user, int targetGrupoScoutId, string? targetGrupoNombre = null)
  {
    if (user.Unidades.Count == 0) return;

    var primeraUnidad = user.Unidades.First();

    if (primeraUnidad.GrupoScout == null)
      throw new ApplicationException("Error de datos: Tu unidad actual no tiene un Grupo Scout asignado.");

    if (primeraUnidad.GrupoScout.Id != targetGrupoScoutId)
    {
      if (targetGrupoNombre is null)
        throw new ApplicationException("Solo puedes crear unidades dentro de un mismo Grupo Scout.");
      else
        throw new ApplicationException(
          $"Los Dirigentes solo pueden estar en unidades del mismo Grupo Scout. " +
          $"Ya perteneces al grupo '{primeraUnidad.GrupoScout.Nombre}' y esta unidad es del grupo '{targetGrupoNombre}'.");
    }
  }
  
  private static void EnsureUserCanJoinUnidad(User user, Unidad unidad)
  {
    if (user.Unidades.Any(u => u.Id == unidad.Id))
      throw new ApplicationException("Ya eres miembro de esta unidad.");

    var rol = user.Tipo?.Nombre;

    if (rol == "Scout")
    {
      if (user.Unidades.Count > 0)
        throw new ApplicationException("Los Scouts solo pueden pertenecer a una unidad a la vez.");

      if (unidad.Rama == null)
        throw new ApplicationException("Error: Esta unidad no tiene una rama asignada. No se puede verificar la edad.");

      var age = CalculateAge(user.FechaNacimiento);
      if (age < unidad.Rama.EdadMinima || age > unidad.Rama.EdadMaxima)
        throw new ApplicationException(
          $"Tu edad ({age} años) no está dentro del rango de edad permitido " +
          $"({unidad.Rama.EdadMinima}-{unidad.Rama.EdadMaxima} años) para la rama de {unidad.Rama.Nombre}.");
    }
    else
    {
      if (unidad.GrupoScout == null)
        throw new ApplicationException("Error de datos: La unidad no tiene Grupo Scout asignado.");

      EnsureSameGrupoIfAlreadyInUnit(user, unidad.GrupoScout.Id, unidad.GrupoScout.Nombre);
    }
  }

  private async Task<string> GenerateUniqueCodigoAsync(int length = 6)
  {
    string codigo;
    do
    {
      codigo = RandomNumberGenerator.GetString(CodigoChars, length);
    } while (await _unidadRepository.CodigoExists(codigo));
    return codigo;
  }

  private static int CalculateAge(DateTime dateOfBirth)
  {
    var birthDateUtc = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc);
    var today = DateTime.UtcNow;
    var age = today.Year - birthDateUtc.Year;
    if (birthDateUtc.Date > today.AddYears(-age)) age--;
    return age;
  }
}
