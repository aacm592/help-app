using AutoMapper;
using backend.data.models;
using backend.dtos.request;
using backend.dtos.responses;
using backend.dtos.responses.progresion;
using backend.enums;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class ObjetivoUsuarioService: IObjetivoUsuarioService
{
  private readonly IUserRepository _userRepository;
  private readonly IObjetivoEducativoRepository _objetivoEducativoRepository;
  private readonly IObjetivoUsuarioRepository _objetivoUsuarioRepository;
  private readonly IUnidadRepository _unidadRepository;
  private readonly IMapper _mapper;

  public ObjetivoUsuarioService(
    IUserRepository userRepository,
    IObjetivoEducativoRepository objetivoEducativoRepository,
    IObjetivoUsuarioRepository objetivoUsuarioRepository,
    IMapper mapper, IUnidadRepository unidadRepository)
  {
    _userRepository = userRepository;
    _objetivoEducativoRepository = objetivoEducativoRepository;
    _objetivoUsuarioRepository = objetivoUsuarioRepository;
    _mapper = mapper;
    _unidadRepository = unidadRepository;
  }
  
  public async Task<ObjetivoUsuarioResponseDto> ElegirObjetivoAsync(int objetivoId, int usuarioId)
  {
    var user = await _userRepository.GetByIdWithTipoAndUnidadesAsync(usuarioId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");
    
    if (user.Tipo.Nombre != "Scout")
      throw new ApplicationException("Solo los Scouts pueden elegir sus objetivos.");

    var objetivo = await _objetivoEducativoRepository.GetByIdAsync(objetivoId);
    if (objetivo == null)
      throw new ApplicationException("Objetivo no encontrado.");

    var unidadDelUsuario = user.Unidades.FirstOrDefault();
    if (unidadDelUsuario == null)
      throw new ApplicationException("Debes pertenecer a una unidad para elegir objetivos.");
        
    if (unidadDelUsuario.RamaId != objetivo.EtapaProgresion.RamaId)
      throw new ApplicationException("Este objetivo no pertenece a tu rama.");

    if (await _objetivoUsuarioRepository.ExistsAsync(usuarioId, objetivoId))
      throw new ApplicationException("Ya has elegido este objetivo.");

    var nuevaRelacion = new ObjetivoUsuario
    {
      UsuarioId = usuarioId,
      ObjetivoEducativoId = objetivoId,
      Status = ObjetivoStatus.Pendiente,
      FechaSeleccion = DateTime.UtcNow
    };

    var relacionGuardada = await _objetivoUsuarioRepository.AddAsync(nuevaRelacion);
        
    relacionGuardada.ObjetivoEducativo = objetivo; 
        
    return _mapper.Map<ObjetivoUsuarioResponseDto>(relacionGuardada);
  }
  
  public async Task<IEnumerable<PendingObjetivoDto>> GetPendingObjetivosByUnidadAsync(int unidadId, int dirigenteId)
  {
    var unidad = await _unidadRepository.GetByIdWithMiembrosAsync(unidadId);
    if (unidad == null)
      throw new ApplicationException("Unidad no encontrada.");

    var esMiembroDirigente = unidad.Usuarios
      .Any(u => u.Id == dirigenteId && u.Tipo.Nombre == "Dirigente");
        
    if (!esMiembroDirigente)
      throw new ApplicationException("No tienes permiso para ver los objetivos de esta unidad.");

    var scoutIds = unidad.Usuarios
      .Where(u => u.Tipo.Nombre == "Scout")
      .Select(u => u.Id);

    if (!scoutIds.Any())
      return new List<PendingObjetivoDto>();

    var objetivosPendientes = await _objetivoUsuarioRepository.GetPendingByScoutIdsAsync(scoutIds);

    return _mapper.Map<IEnumerable<PendingObjetivoDto>>(objetivosPendientes);
  }
  
  public async Task<ObjetivoUsuarioResponseDto> ValidarObjetivoAsync(ValidarObjetivoDto dto, int dirigenteId)
  {
    var objetivoUsuario = await _objetivoUsuarioRepository.GetByUsuarioYObjetivoAsync(dto.UsuarioId, dto.ObjetivoId);

    if (objetivoUsuario == null)
      throw new ApplicationException("La solicitud de este objetivo no existe.");

    if (objetivoUsuario.Status != ObjetivoStatus.Pendiente)
      throw new ApplicationException("Este objetivo no está pendiente de validación.");

    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(dto.UsuarioId);
    if (scout == null || !scout.Unidades.Any())
      throw new ApplicationException("El Scout no se encuentra o no pertenece a ninguna unidad.");

    var unidadDelScout = scout.Unidades.First(); 
    
    var dirigente = await _userRepository.GetByIdWithTipoAndUnidadesAsync(dirigenteId);
    if (dirigente == null)
      throw new ApplicationException("Dirigente no encontrado.");

    var dirigenteEstaEnUnidad = dirigente.Unidades.Any(u => u.Id == unidadDelScout.Id);

    if (!dirigenteEstaEnUnidad)
      throw new ApplicationException("No tienes permiso para validar objetivos de este Scout, ya que no pertenecen a tu misma unidad.");

    objetivoUsuario.Status = ObjetivoStatus.Cumplido;
    objetivoUsuario.FechaAprobacion = DateTime.UtcNow;
    objetivoUsuario.DirigenteAproboId = dirigenteId;

    await _objetivoUsuarioRepository.UpdateAsync(objetivoUsuario);

    return _mapper.Map<ObjetivoUsuarioResponseDto>(objetivoUsuario);
  }
  
  public async Task DenegarObjetivoAsync(ValidarObjetivoDto dto, int dirigenteId)
  {
    var objetivoUsuario = await _objetivoUsuarioRepository.GetByUsuarioYObjetivoAsync(dto.UsuarioId, dto.ObjetivoId);

    if (objetivoUsuario == null)
      throw new ApplicationException("La solicitud de este objetivo no existe.");

    if (objetivoUsuario.Status != ObjetivoStatus.Pendiente)
      throw new ApplicationException("Este objetivo no está pendiente de validación.");

    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(dto.UsuarioId);
    if (scout == null || !scout.Unidades.Any())
      throw new ApplicationException("El Scout no se encuentra o no pertenece a ninguna unidad.");

    var unidadDelScout = scout.Unidades.First(); 
    
    var dirigente = await _userRepository.GetByIdWithTipoAndUnidadesAsync(dirigenteId);
    if (dirigente == null)
      throw new ApplicationException("Dirigente no encontrado.");

    var dirigenteEstaEnUnidad = dirigente.Unidades.Any(u => u.Id == unidadDelScout.Id);

    if (!dirigenteEstaEnUnidad)
      throw new ApplicationException("No tienes permiso para denegar objetivos de este Scout, ya que no pertenecen a tu misma unidad.");

    await _objetivoUsuarioRepository.DeleteAsync(objetivoUsuario);
  }
  
  public async Task<IEnumerable<ObjetivoUsuarioResponseDto>> GetMisObjetivosAsync(int usuarioId)
  {
    var objetivosDelUsuario = await _objetivoUsuarioRepository.GetByUsuarioIdAsync(usuarioId);
    return _mapper.Map<IEnumerable<ObjetivoUsuarioResponseDto>>(objetivosDelUsuario);
  }

  public async Task<IEnumerable<RamaObjetivosDto>> GetScoutObjetivosAgrupadosAsync(int scoutId, int solicitanteId)
  {
    var solicitante = await _userRepository.GetByIdWithTipoAndUnidadesAsync(solicitanteId);
    if (solicitante == null)
      throw new ApplicationException("Usuario solicitante no encontrado.");

    bool tienePermiso = false;

    if (solicitanteId == scoutId)
      tienePermiso = true;
    else if (solicitante.Tipo?.Nombre == "Dirigente")
    {
      var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(scoutId);
      if (scout == null || !scout.Unidades.Any())
        throw new ApplicationException("El Scout no se encuentra o no pertenece a ninguna unidad.");

      var scoutUnidadIds = scout.Unidades.Select(u => u.Id).ToHashSet();
      var dirigenteEstaEnUnidad = solicitante.Unidades.Any(u => scoutUnidadIds.Contains(u.Id));

      if (dirigenteEstaEnUnidad)
        tienePermiso = true;
    }
    
    if (!tienePermiso)
      throw new ApplicationException("No tienes permiso para ver los objetivos de este Scout.");

    return await GetAndGroupObjetivos(scoutId);
  }

  public async Task<IEnumerable<ObjetivoEtapaResumeDto>> GetResume(int scoutId)
  {
    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(scoutId);
    if (scout == null || !scout.Unidades.Any())
      throw new ApplicationException("El Scout no pertenece a ninguna unidad.");

    var ramaId = scout.Unidades.First().RamaId;

    var objetivosCatalogo = await _objetivoEducativoRepository.GetByRamaIdAsync(ramaId);

    var progresoUsuario = await _objetivoUsuarioRepository.GetByUsuarioIdAsync(scoutId);
    var dictProgreso = progresoUsuario.ToDictionary(ou => ou.ObjetivoEducativoId);

    var resumen = objetivosCatalogo
      .GroupBy(oe => new { oe.EtapaProgresionId, oe.EtapaProgresion.Nombre })
      .OrderBy(g => g.Key.EtapaProgresionId) 
      .Select(etapaGroup => new ObjetivoEtapaResumeDto
      {
        Etapa = etapaGroup.Key.Nombre,
        ObjetivosAreaResume = etapaGroup
          .GroupBy(oe => oe.AreaCrecimiento.Nombre)
          .Select(areaGroup => new ObjetivoAreaResumeDto
          {
            Area = areaGroup.Key,
            TotalQuantity = areaGroup.Count(),
            InProgressQuantity = areaGroup.Count(oe => 
              dictProgreso.TryGetValue(oe.Id, out var p) && p.Status == ObjetivoStatus.Pendiente),
            DoneQuantity = areaGroup.Count(oe => 
              dictProgreso.TryGetValue(oe.Id, out var p) && p.Status == ObjetivoStatus.Cumplido)
          })
          .OrderBy(a => a.Area)
          .ToList()
      })
      .ToList();

    return resumen;
  }

  public async Task<IEnumerable<ObjetivoEtapaResumeDto>> GetResume(int scoutId, int dirigenteId)
  {
    var scout = await _userRepository.GetByIdWithTipoAndUnidadesAsync(scoutId);
    if (scout == null || !scout.Unidades.Any())
      throw new ApplicationException("El Scout no se encuentra o no pertenece a ninguna unidad.");

    var dirigente = await _userRepository.GetByIdWithTipoAndUnidadesAsync(dirigenteId);
    if (dirigente == null)
      throw new ApplicationException("Dirigente no encontrado.");

    var unidadDelScout = scout.Unidades.First(); 
    var dirigenteEstaEnUnidad = dirigente.Unidades.Any(u => u.Id == unidadDelScout.Id);

    if (!dirigenteEstaEnUnidad)
      throw new ApplicationException("No tienes permiso para validar objetivos de este Scout, ya que no pertenecen a tu misma unidad.");

    return await GetResume(scoutId);
  }

  private async Task<IEnumerable<RamaObjetivosDto>> GetAndGroupObjetivos(int scoutId)
  {
    var objetivos = await _objetivoUsuarioRepository.GetByUsuarioIdWithFullTreeAsync(scoutId);

    var objetivosAgrupados = objetivos
      .GroupBy(ou => ou.ObjetivoEducativo.EtapaProgresion.Rama)
      .Select(grupoRama => new RamaObjetivosDto
      {
        Id = grupoRama.Key.Id,
        Nombre = grupoRama.Key.Nombre,
        Etapas = grupoRama
          .GroupBy(ou => ou.ObjetivoEducativo.EtapaProgresion)
          .Select(grupoEtapa => new EtapaObjetivosDto
          {
            Id = grupoEtapa.Key.Id,
            Nombre = grupoEtapa.Key.Nombre,
            
            Areas = grupoEtapa 
              .GroupBy(ou => ou.ObjetivoEducativo.AreaCrecimiento)
              .Select(grupoArea => new AreaObjetivosDto
              {
                Id = grupoArea.Key.Id,
                Nombre = grupoArea.Key.Nombre,
                Objetivos = _mapper.Map<List<ObjetivoUsuarioResponseDto>>(grupoArea.ToList()),
              })
              .OrderBy(a => a.Nombre)
              .ToList()
          })
          .OrderBy(e => e.Id)
          .ToList()
      })
      .OrderBy(r => r.Id)
      .ToList();

    return objetivosAgrupados;
  }
}
