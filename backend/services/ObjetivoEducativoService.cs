using AutoMapper;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class ObjetivoEducativoService : IObjetivoEducativoService
{
  private readonly IObjetivoEducativoRepository _objetivoRepository;
  private readonly IObjetivoUsuarioRepository _objetivoUsuarioRepository;
  private readonly IUserRepository _userRepository;

  private readonly IMapper _mapper;

  public ObjetivoEducativoService(IObjetivoEducativoRepository objetivoRepository, IMapper mapper, IObjetivoUsuarioRepository objetivoUsuarioRepository, IUserRepository userRepository)
  {
    _objetivoRepository = objetivoRepository;
    _mapper = mapper;
    _objetivoUsuarioRepository = objetivoUsuarioRepository;
    _userRepository = userRepository;
  }

  public async Task<IEnumerable<ObjetivoEducativoDto>> GetByEtapaIdAsync(int etapaId, int usuarioId)
  {
    var allObjetivos = await _objetivoRepository.GetByEtapaIdAsync(etapaId);
    var userObjetivoIds = await _objetivoUsuarioRepository.GetByUsuarioIdAsync(usuarioId);

    var mappedObjetivos = _mapper.Map<IEnumerable<ObjetivoEducativoDto>>(allObjetivos);

    if (userObjetivoIds.FirstOrDefault() == null)
      return mappedObjetivos;

    foreach (var obj in mappedObjetivos)
    {
      var objUser = userObjetivoIds.FirstOrDefault(x => x.ObjetivoEducativoId == obj.Id);
      if (objUser != null)
        obj.Status = objUser.Status.ToString();
    }

    return mappedObjetivos;
  }

  public async Task<IEnumerable<ObjetivoEducativoDto>> GetByEtapaIdAsync(int etapaId, int userId, int diriId)
  {
    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (scout == null || !scout.Unidades.Any())
      throw new ApplicationException("El Scout no se encuentra o no pertenece a ninguna unidad.");

    var dirigente = await _userRepository.GetByIdWithTipoAndUnidadesAsync(diriId);
    if (dirigente == null)
      throw new ApplicationException("Dirigente no encontrado.");

    var unidadDelScout = scout.Unidades.First();
    var dirigenteEstaEnUnidad = dirigente.Unidades.Any(u => u.Id == unidadDelScout.Id);

    if (!dirigenteEstaEnUnidad)
      throw new ApplicationException("El scout no pertenece a tu unidad.");

    return await GetByEtapaIdAsync(etapaId, userId);
  }
}
