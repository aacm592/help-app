using System.Security.Claims;
using backend.dtos.registros;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GrupoScoutController : ControllerBase
{
  private readonly IGrupoScoutService _grupoScoutService;

  public GrupoScoutController(IGrupoScoutService grupoScoutService)
  {
    _grupoScoutService = grupoScoutService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllGruposScout()
  {
    var grupos = await _grupoScoutService.GetAllAsync();
    return Ok(grupos);
  }
  
  [HttpGet("{distritoId}")]
  public async Task<IActionResult> GetByDistrito(int distritoId)
  {
    var grupos = await _grupoScoutService.GetByDistritoIdAsync(distritoId);
    return Ok(grupos);
  }
  
  [Authorize(Roles = "2")]
  [Authorize(Roles = "p1, p2")]
  [HttpGet("unidades/users")]
  public async Task<IActionResult> GetUsers()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var resultado = await _grupoScoutService.UsersById(userId);
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
