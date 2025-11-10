using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DistritoController : ControllerBase
{
  private readonly IDistritoService _distritoService;

  public DistritoController(IDistritoService distritoService)
  {
    _distritoService = distritoService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var distritos = await _distritoService.GetAllAsync();
    return Ok(distritos);
  }
}
