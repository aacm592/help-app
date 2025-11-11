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
}
