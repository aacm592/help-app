using System.Security.Claims;
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
  
  [Authorize(Roles = "2")]
  [Authorize(Roles = "p3, p4")]
  [HttpGet ("registers")]
  public async Task<IActionResult> GetRegisters()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var resultado = await _distritoService.GetResumenRegistrosByDistritoId(userId);
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
