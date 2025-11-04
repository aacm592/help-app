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
    var creador = await _userRepository.GetByIdAsync(creadorId);
    if (creador == null)
      throw new ApplicationException("El usuario creador no existe.");

    string codigo;
    do
    {
      codigo = GenerateRandomCodigo();
    } while (await _unidadRepository.CodigoExists(codigo));

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

  private string GenerateRandomCodigo(int length = 6)
  {
    return RandomNumberGenerator.GetString(CodigoChars, length);
  }
}
