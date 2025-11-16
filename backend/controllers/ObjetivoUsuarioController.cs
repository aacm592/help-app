using System.Security.Claims;
using backend.dtos.request;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ObjetivoUsuarioController : ControllerBase
{
  private readonly IObjetivoUsuarioService _objetivoUsuarioService;

  public ObjetivoUsuarioController(IObjetivoUsuarioService objetivoUsuarioService)
  {
    _objetivoUsuarioService = objetivoUsuarioService;
  }

  [HttpPost("elegir")]
  public async Task<IActionResult> ElegirObjetivo([FromBody] ElegirObjetivoDto dto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var resultado = await _objetivoUsuarioService.ElegirObjetivoAsync(dto.ObjetivoId, userId);
            
      return Ok(resultado);
    }
    catch (ApplicationException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno: {ex.Message}");
    }
  }
  
  [Authorize(Roles = "2")]
  [HttpGet("unidad/{unidadId:int}/pendientes")]
  public async Task<IActionResult> GetPendientesPorUnidad(int unidadId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var dirigenteId))
        return Unauthorized("Token de usuario inválido.");

      var pendientes = await _objetivoUsuarioService.GetPendingObjetivosByUnidadAsync(unidadId, dirigenteId);
        
      return Ok(pendientes);
    }
    catch (ApplicationException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno: {ex.Message}");
    }
  }
  
  [Authorize(Roles = "2")]
  [HttpPost("validar")]
  public async Task<IActionResult> ValidarObjetivo([FromBody] ValidarObjetivoDto dto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var dirigenteId))
        return Unauthorized("Token de usuario inválido.");

      var resultado = await _objetivoUsuarioService.ValidarObjetivoAsync(dto, dirigenteId);
        
      return Ok(resultado);
    }
    catch (ApplicationException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno: {ex.Message}");
    }
  }
  
  [Authorize(Roles = "2")] 
  [HttpPost("denegar")]
  public async Task<IActionResult> DenegarObjetivo([FromBody] ValidarObjetivoDto dto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var dirigenteId))
        return Unauthorized("Token de usuario inválido.");

      await _objetivoUsuarioService.DenegarObjetivoAsync(dto, dirigenteId);
        
      return Ok(new { Message = "Objetivo denegado y eliminado correctamente." });
    }
    catch (ApplicationException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno: {ex.Message}");
    }
  }
  
  [Authorize]
  [HttpGet("mis-objetivos")]
  public async Task<IActionResult> GetMisObjetivos()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var objetivos = await _objetivoUsuarioService.GetMisObjetivosAsync(userId);
        
      return Ok(objetivos);
    }
    catch (ApplicationException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno: {ex.Message}");
    }
  }
  
  [Authorize]
  [HttpGet("scout/{scoutId:int}/agrupados")]
  public async Task<IActionResult> GetScoutObjetivosAgrupados(int scoutId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var solicitanteId))
        return Unauthorized("Token de usuario inválido.");

      var resultado = await _objetivoUsuarioService.GetScoutObjetivosAgrupadosAsync(scoutId, solicitanteId);
        
      return Ok(resultado);
    }
    catch (ApplicationException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno: {ex.Message}");
    }
  }
}
