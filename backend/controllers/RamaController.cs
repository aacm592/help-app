using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RamaController : ControllerBase
{
  private readonly IRamaService _ramaService;

  public RamaController(IRamaService ramaService)
  {
    _ramaService = ramaService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllRamas()
  {
    var ramas = await _ramaService.GetAllAsync();
    return Ok(ramas);
  }
}
