using AutoMapper;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class RamaService : IRamaService
{
  private readonly IRamaRepository _ramaRepository;
  private readonly IMapper _mapper;

  public RamaService(IRamaRepository ramaRepository, IMapper mapper)
  {
    _ramaRepository = ramaRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<CatalogDto>> GetAllAsync()
  {
    var ramas = await _ramaRepository.GetAll();
    return _mapper.Map<IEnumerable<CatalogDto>>(ramas);
  }
}
