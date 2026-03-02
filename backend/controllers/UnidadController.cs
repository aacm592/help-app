using System.Security.Claims;
using backend.dtos.request;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[ApiController]
[Route("api/[controller]")]
public class UnidadController : ControllerBase
{
  private readonly IUnidadService _unidadService;

  public UnidadController(IUnidadService unidadService)
  {
    _unidadService = unidadService;
  }

  [Authorize(Roles = "2")]
  [HttpPost("crear")]
  public async Task<IActionResult> CreateUnidad([FromBody] CreateUnidadDto createDto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

      if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
        return Unauthorized("No se pudo identificar al usuario desde el token.");


      var responseDto = await _unidadService.Create(createDto, userId);
      return Ok(responseDto);
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
  [HttpPost("unirse")]
  public async Task<IActionResult> JoinUnidad([FromBody] JoinUnidadDto joinDto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

      if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
        return Unauthorized("No se pudo identificar al usuario desde el token.");

      var unidadResponse = await _unidadService.JoinUnidad(joinDto.Codigo, userId);
      return Ok(unidadResponse);
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
  [HttpPost("salir")]
  public async Task<IActionResult> SalirDeUnidad([FromBody] SalirUnidadDto dto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _unidadService.SalirDeUnidadAsync(dto.UnidadId, userId);
      return Ok(new { Message = "Has salido de la unidad." });
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
  [HttpPost("remover")]
  public async Task<IActionResult> RemoverDeUnidad([FromBody] RemoveUsuarioDto dto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var dirigenteId))
        return Unauthorized("Token de usuario inválido.");

      await _unidadService.RemoverDeUnidadAsync(dto.UnidadId, dto.UsuarioToRemoveId, dirigenteId);
      return Ok(new { Message = "Usuario removido de la unidad." });
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
  [HttpGet("miembros/{unidadId:int}")]
  public async Task<IActionResult> GetMiembros(int unidadId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var dirigenteId))
        return Unauthorized("Token de usuario inválido.");

      var miembros = await _unidadService.GetMiembrosUnidadAsync(unidadId, dirigenteId);
      return Ok(miembros);
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
  [Authorize(Roles = "p1, p2")]
  [HttpGet("/unidad/{unidadId}/registers")]
  public async Task<IActionResult> GetUnidadById(int unidadId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var resultado = await _unidadService.GetUnidadMembersAndRegisters(userId, unidadId);
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
