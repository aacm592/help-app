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
    var objetivos = await _objetivoService.GetByEtapaIdAsync(etapaId);
    return Ok(objetivos);
  }
}
