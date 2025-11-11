using AutoMapper;
using backend.data.models;
using backend.dtos.responses;
using backend.enums;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class ObjetivoUsuarioService: IObjetivoUsuarioService
{
  private readonly IUserRepository _userRepository;
  private readonly IObjetivoEducativoRepository _objetivoEducativoRepository;
  private readonly IObjetivoUsuarioRepository _objetivoUsuarioRepository;
  private readonly IMapper _mapper;

  public ObjetivoUsuarioService(
    IUserRepository userRepository,
    IObjetivoEducativoRepository objetivoEducativoRepository,
    IObjetivoUsuarioRepository objetivoUsuarioRepository,
    IMapper mapper)
  {
    _userRepository = userRepository;
    _objetivoEducativoRepository = objetivoEducativoRepository;
    _objetivoUsuarioRepository = objetivoUsuarioRepository;
    _mapper = mapper;
  }
  
  public async Task<ObjetivoUsuarioResponseDto> ElegirObjetivoAsync(int objetivoId, int usuarioId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(usuarioId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");
    
    if (user.Tipo.Nombre != "Scout")
      throw new ApplicationException("Solo los Scouts pueden elegir sus objetivos.");

    var objetivo = await _objetivoEducativoRepository.GetByIdAsync(objetivoId);
    if (objetivo == null)
      throw new ApplicationException("Objetivo no encontrado.");

    var unidadDelUsuario = user.Unidades.FirstOrDefault();
    if (unidadDelUsuario == null)
      throw new ApplicationException("Debes pertenecer a una unidad para elegir objetivos.");
        
    if (unidadDelUsuario.RamaId != objetivo.EtapaProgresion.RamaId)
      throw new ApplicationException("Este objetivo no pertenece a tu rama.");

    if (await _objetivoUsuarioRepository.ExistsAsync(usuarioId, objetivoId))
      throw new ApplicationException("Ya has elegido este objetivo.");

    var nuevaRelacion = new ObjetivoUsuario
    {
      UsuarioId = usuarioId,
      ObjetivoEducativoId = objetivoId,
      Status = ObjetivoStatus.Pendiente 
    };

    var relacionGuardada = await _objetivoUsuarioRepository.AddAsync(nuevaRelacion);
        
    relacionGuardada.ObjetivoEducativo = objetivo; 
        
    return _mapper.Map<ObjetivoUsuarioResponseDto>(relacionGuardada);
  }
}
