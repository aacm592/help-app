using AutoMapper;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class ObjetivoEducativoService : IObjetivoEducativoService
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
}
