using AutoMapper;
using backend.data.models.especialidades;
using backend.dtos.request;
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
      throw new ApplicationException("Debes pertenecer a una unidad para seleccionar requisitos.");
    
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

  public async Task ValidarRequerimiento(ValidarObjetivoDto dto, int dirigenteId)
  {
    var requerimiento = await _requisitoEspRepository.GetRequisitoByUserIdAndRequisitoId(dto.UsuarioId, dto.ObjetivoId);
    if (requerimiento == null)
      throw new ApplicationException("Solicitud no encontrada.");
    
    if (requerimiento.Status != ObjetivoStatus.Pendiente)
      throw new ApplicationException("Este requerimiento no está pendiente de validación.");
    
    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(dto.UsuarioId);
    if (scout == null || !scout.Unidades.Any())
      throw new ApplicationException("El Scout no se encuentra o no pertenece a ninguna unidad.");

    var dirigente = await _userRepository.GetByIdWithTipoAndUnidadesAsync(dirigenteId);
    if (dirigente == null)
      throw new ApplicationException("Dirigente no encontrado.");

    var unidadDelScout = scout.Unidades.First(); 
    var dirigenteEstaEnUnidad = dirigente.Unidades.Any(u => u.Id == unidadDelScout.Id);

    if (!dirigenteEstaEnUnidad)
      throw new ApplicationException("No tienes permiso para validar objetivos de este Scout, ya que no pertenecen a tu misma unidad.");

    requerimiento.Status = ObjetivoStatus.Cumplido;
    requerimiento.DirigenteAproboId = dirigente.Id;
    requerimiento.FechaAprobacion = DateTime.UtcNow;
    
    await _requisitoEspRepository.UpdateReqEspUser(requerimiento);
  }

  public async Task<IEnumerable<UserRequisitoEspDto>> GetReqByUnidad(int unidadId, int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");
    
    var unidad = user.Unidades.FirstOrDefault(u => u.Id == unidadId);
    if (unidad == null)
      throw new ApplicationException("No eres parte de esta unidad.");
    
    var requerimientos = await _requisitoEspRepository.GetPendientesByUnidad(unidadId);
    
    return _mapper.Map<List<UserRequisitoEspDto>>(requerimientos);
  }

  public async Task<IEnumerable<EspecialidadResumeDto>> GetUserResume(int userId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    var unidadDelScout = user.Unidades.First();
    
    if (user == null || !user.Unidades.Any())
      throw new ApplicationException("El usuario no se encuentró o no pertenece a ninguna unidad.");
    
    var requisitos = await _requisitoEspRepository.GetRequisitosByUser(userId);
    requisitos = requisitos.Where(x => x.Requisito.Especialidad.RamaId == unidadDelScout.RamaId);
    
    var result =  new Dictionary<string, EspecialidadResumeDto>();

    foreach (var requisito in requisitos)
    {
      string name = requisito.Requisito.Especialidad.Nombre;
      var status =  requisito.Status;
      if (result.ContainsKey(name))
      {
        switch (status)
        {
          case ObjetivoStatus.Pendiente:
            result[name].InProgressQuantity++;
            break;
          case ObjetivoStatus.Cumplido:
            result[name].DoneQuantity++;
            break;
        }
      }
      else
      {
        var newRequisito = new EspecialidadResumeDto()
        {
          Name = name,
          Status = status.ToString(),
          RequirementQuantity = requisito.Requisito.Especialidad.Requisitos.Count(),
          InProgressQuantity = status == ObjetivoStatus.Pendiente ? 1 : 0,
          DoneQuantity = status == ObjetivoStatus.Cumplido ? 1 : 0,
        };
        
        result.Add(name, newRequisito);
      }
    }

    return result.Values.ToList();
  }

  public async Task<IEnumerable<EspecialidadResumeDto>> GetUserResume(int userId, int dirigenteId)
  {
    
    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(userId);
    if (scout == null || !scout.Unidades.Any())
      throw new ApplicationException("El Scout no se encuentra o no pertenece a ninguna unidad.");

    var dirigente = await _userRepository.GetByIdWithTipoAndUnidadesAsync(dirigenteId);
    if (dirigente == null)
      throw new ApplicationException("Dirigente no encontrado.");

    var unidadDelScout = scout.Unidades.First(); 
    var dirigenteEstaEnUnidad = dirigente.Unidades.Any(u => u.Id == unidadDelScout.Id);

    if (!dirigenteEstaEnUnidad)
      throw new ApplicationException("No tienes permiso para validar objetivos de este Scout, ya que no pertenecen a tu misma unidad.");

    return await GetUserResume(userId);
  }
}
