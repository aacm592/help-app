using System.Security.Claims;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EspecialidadController: ControllerBase
{
  private readonly IEspecialidadServer _especialidadServer;

  public EspecialidadController(IEspecialidadServer especialidadServer)
  {
    _especialidadServer = especialidadServer;
  }

  [HttpGet("rama")]
  public async Task<IActionResult> GetByRama(int ramaId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");
      
      var especialidades = await _especialidadServer.GetEspecialidadesByRama(ramaId,  userId);
      return Ok(especialidades);
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
