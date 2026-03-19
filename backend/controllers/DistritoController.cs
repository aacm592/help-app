using System.Security.Claims;
using backend.enums;
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
  [HttpGet ("registers/enviadosDistrito")]
  public async Task<IActionResult> GetEnviadosDistrito()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var status = new List<RegistroStatus>()
      {
        RegistroStatus.EnviadoDistrito
      };
      var resultado = await _distritoService.GetResumenRegistrosByDistritoId(userId, status);
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
  
  [Authorize(Roles = "2")]
  [Authorize(Roles = "p3, p4")]
  [HttpGet ("registers/resumen")]
  public async Task<IActionResult> GetRegistersResumen()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var status = new List<RegistroStatus>()
      {
        RegistroStatus.RegistroDistrito,
        RegistroStatus.EnviadoNacional,
        RegistroStatus.RegistroNacional
      };
      
      var resultado = await _distritoService.GetResumenRegistrosByDistritoId(userId, status);
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
  
  [Authorize(Roles = "2")]
  [Authorize(Roles = "p3, p4")]
  [HttpGet ("registers/")]
  public async Task<IActionResult> GetRegisters()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var status = new List<RegistroStatus>()
      {
        RegistroStatus.RegistroDistrito,
        RegistroStatus.EnviadoNacional,
        RegistroStatus.RegistroNacional
      };
      
      var resultado = await _distritoService.GetRegistrosDistrito(userId, status);
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
  
  [Authorize(Roles = "2")]
  [Authorize(Roles = "p3")]
  [HttpGet ("admins")]
  public async Task<IActionResult> GetAdmins()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");
      
      var resultado = await _distritoService.GetAdmins(userId);
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
