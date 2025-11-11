using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EtapaProgresionController : ControllerBase
{
  private readonly IEtapaProgresionService _etapaService;

  public EtapaProgresionController(IEtapaProgresionService etapaService)
  {
    _etapaService = etapaService;
  }

  [HttpGet("rama/{ramaId}")]
  public async Task<IActionResult> GetByRama(int ramaId)
  {
    var etapas = await _etapaService.GetByRamaIdAsync(ramaId);
    return Ok(etapas);
  }
}
