using AutoMapper;
using backend.dtos.responses.especialidades;
using backend.enums;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class EspecialidadServer: IEspecialidadServer
{
  private readonly IRequisitoEspRepository _requisitoEspRepository;
  private readonly IEspecialidadRepository _espRepository;
  private readonly IMapper _mapper;

  public EspecialidadServer(IRequisitoEspRepository requisitoEspRepository, IEspecialidadRepository espRepository, IMapper mapper)
  {
    _requisitoEspRepository = requisitoEspRepository;
    _espRepository = espRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<EspecialidadDto>> GetEspecialidadesByRama(int ramaId, int userId)
  {
    var especialidades = await _espRepository.GetEspecialidadesByRama(ramaId);
    var requisitosUser = await _requisitoEspRepository.GetRequisitosByUser(userId);

    var especialidadesDto = _mapper.Map<List<EspecialidadDto>>(especialidades);

    foreach (var espDto in especialidadesDto)
    {
      int aprobadosCount = 0;

      foreach (var reqDto in espDto.Requerimientos)
      {
        var rel = requisitosUser.FirstOrDefault(r => r.RequisitoId == reqDto.Id);
        reqDto.Status = rel?.Status.ToString() ?? "Sin iniciar";

        if (rel?.Status == ObjetivoStatus.Cumplido) 
          aprobadosCount++;
      }

      espDto.Status = aprobadosCount == 0 ? "Sin iniciar" : 
        aprobadosCount == espDto.Requerimientos.Count ? "Completada" : 
        "En Progreso";
    }

    return especialidadesDto;
  }
}
