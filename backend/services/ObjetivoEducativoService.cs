using AutoMapper;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class ObjetivoEducativoService: IObjetivoEducativoService
{
  private readonly IObjetivoEducativoRepository _objetivoRepository;
  private readonly IMapper _mapper;

  public ObjetivoEducativoService(IObjetivoEducativoRepository objetivoRepository, IMapper mapper)
  {
    _objetivoRepository = objetivoRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<ObjetivoEducativoDto>> GetByEtapaIdAsync(int etapaId)
  {
    var objetivos = await _objetivoRepository.GetByEtapaIdAsync(etapaId);
    return _mapper.Map<IEnumerable<ObjetivoEducativoDto>>(objetivos);
  }
}
