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
}
