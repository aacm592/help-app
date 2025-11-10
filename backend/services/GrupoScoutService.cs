using AutoMapper;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class GrupoScoutService : IGrupoScoutService
{
  private readonly IGrupoScoutRepository _grupoScoutRepository;
  private readonly IMapper _mapper;

  public GrupoScoutService(IGrupoScoutRepository grupoScoutRepository, IMapper mapper)
  {
    _grupoScoutRepository = grupoScoutRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<CatalogDto>> GetAllAsync()
  {
    var grupos = await _grupoScoutRepository.GetAll();
    return _mapper.Map<IEnumerable<CatalogDto>>(grupos);
  }
  
  public async Task<IEnumerable<CatalogDto>> GetByDistritoIdAsync(int distritoId)
  {
    var grupos = await _grupoScoutRepository.GetByDistritoIdAsync(distritoId);
    return _mapper.Map<IEnumerable<CatalogDto>>(grupos);
  }
}
