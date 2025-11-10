using AutoMapper;
using backend.dtos.responses;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class DistritoService : IDistritoService
{
  private readonly IDistritoRepository _distritoRepository;
  private readonly IMapper _mapper;

  public DistritoService(IDistritoRepository distritoRepository, IMapper mapper)
  {
    _distritoRepository = distritoRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<CatalogDto>> GetAllAsync()
  {
    var distritos = await _distritoRepository.GetAll();
    return _mapper.Map<IEnumerable<CatalogDto>>(distritos);
  }
}
