using AutoMapper;
using backend.data.models.especialidades;
using backend.dtos.responses.especialidades;
using backend.enums;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class EspecialidadServer: IEspecialidadServer
{
  private readonly IRequisitoEspRepository _requisitoEspRepository;
  private readonly IEspecialidadRepository _espRepository;
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;

  public EspecialidadServer(IRequisitoEspRepository requisitoEspRepository, IEspecialidadRepository espRepository, IMapper mapper, IUserRepository userRepository)
  {
    _requisitoEspRepository = requisitoEspRepository;
    _espRepository = espRepository;
    _mapper = mapper;
    _userRepository = userRepository;
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

  public async Task SelectRequerimiento(int requerimientoId, int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");
      
    var requerimiento = await _requisitoEspRepository.GetRequisito(requerimientoId);
    if (requerimiento == null)
      throw new ApplicationException("Requerimiento no encontrado.");

    var unidadDelUsuario = user.Unidades.FirstOrDefault();
    if (unidadDelUsuario == null)
      throw new ApplicationException("Debes pertenecer a una unidad para seleccionar objetivos.");
    
    if (unidadDelUsuario.RamaId != requerimiento.Especialidad.RamaId)
      throw new ApplicationException("Esta especialidad no pertenece a tu rama.");
    
    var requisitosActuales = await _requisitoEspRepository.GetRequisitosByUser(userId);
    var yaExiste = requisitosActuales.Any(r => r.RequisitoId == requerimientoId);
    if (yaExiste)
      throw new ApplicationException("Ya has seleccionado este requerimiento.");
    
    var nuevaRelacion = new RequisitoEspUser()
    {
      UsuarioId = userId,
      RequisitoId = requerimientoId,
      FechaSeleccion =  DateTime.UtcNow,
      Status = ObjetivoStatus.Pendiente
    };

    await _requisitoEspRepository.Add(nuevaRelacion);
  }
}
