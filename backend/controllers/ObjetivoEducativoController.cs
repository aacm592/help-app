using System.Security.Claims;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ObjetivoEducativoController : ControllerBase
{
  private readonly IObjetivoEducativoService _objetivoService;

  public ObjetivoEducativoController(IObjetivoEducativoService objetivoService)
  {
    _objetivoService = objetivoService;
  }

  [HttpGet("etapa/{etapaId:int}")]
  public async Task<IActionResult> GetByEtapa(int etapaId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var objetivos = await _objetivoService.GetByEtapaIdAsync(etapaId, userId);
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
}
