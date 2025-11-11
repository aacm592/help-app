using AutoMapper;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class ObjetivoEducativoService: IObjetivoEducativoService
{
  private readonly IObjetivoEducativoRepository _objetivoRepository;
  private readonly IObjetivoUsuarioRepository _objetivoUsuarioRepository;
  private readonly IMapper _mapper;

  public ObjetivoEducativoService(IObjetivoEducativoRepository objetivoRepository, IMapper mapper, IObjetivoUsuarioRepository objetivoUsuarioRepository)
  {
    _objetivoRepository = objetivoRepository;
    _mapper = mapper;
    _objetivoUsuarioRepository = objetivoUsuarioRepository;
  }

  public async Task<IEnumerable<ObjetivoEducativoDto>> GetByEtapaIdAsync(int etapaId, int usuarioId)
  {
    var allObjetivos = await _objetivoRepository.GetByEtapaIdAsync(etapaId);
    var userObjetivoIds = await _objetivoUsuarioRepository.GetUserObjetivoIdsAsync(usuarioId);

    if (userObjetivoIds.Count == 0)
      return _mapper.Map<IEnumerable<ObjetivoEducativoDto>>(allObjetivos);

    var filteredObjetivos = allObjetivos
      .Where(obj => !userObjetivoIds.Contains(obj.Id));

    return _mapper.Map<IEnumerable<ObjetivoEducativoDto>>(filteredObjetivos);
  }
}
