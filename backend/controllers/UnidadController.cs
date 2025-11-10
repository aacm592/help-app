using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using backend.dtos.request;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[ApiController]
[Route("api/[controller]")]
public class UnidadController: ControllerBase
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
      {
        return Unauthorized("No se pudo identificar al usuario desde el token.");
      }
      
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
}
