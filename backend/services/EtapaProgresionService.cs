using AutoMapper;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class EtapaProgresionService: IEtapaProgresionService
{
  private readonly IEtapaProgresionRepository _etapaRepository;
  private readonly IMapper _mapper;

  public EtapaProgresionService(IEtapaProgresionRepository etapaRepository, IMapper mapper)
  {
    _etapaRepository = etapaRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<CatalogDto>> GetByRamaIdAsync(int ramaId)
  {
    var etapas = await _etapaRepository.GetByRamaIdAsync(ramaId);
    return _mapper.Map<IEnumerable<CatalogDto>>(etapas);
  }
}