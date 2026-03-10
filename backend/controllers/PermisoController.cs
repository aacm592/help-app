using System.Security.Claims;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PermisoController : ControllerBase
{
  private readonly IPermisosService _permisosService;

  public PermisoController(IPermisosService permisosService)
  {
    _permisosService = permisosService;
  }

  [Authorize(Roles = "2")]
  [Authorize(Roles = "p1")]
  [HttpPost("admin/grupo")]
  public async Task<IActionResult> AddGroupAdmin([FromBody] string userName)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _permisosService.AddGroupAdmin(userId, userName);
      return Ok(new { Message = "Administrador agregado" });
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
  [Authorize(Roles = "p1")]
  [HttpDelete("admin/grupo/{scoutId}")]
  public async Task<IActionResult> DeleteGroupAdmin(int scoutId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _permisosService.DeleteGroupAdmin(userId, scoutId);
      return Ok(new { Message = "Administrador eliminado" });
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
  [HttpPost("admin/distrito")]
  public async Task<IActionResult> AddDistritoAdmin([FromBody] string userName)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _permisosService.AddDistritoAdmin(userId, userName);
      return Ok(new { Message = "Administrador agregado" });
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
  [HttpDelete("admin/distrito/{scoutId}")]
  public async Task<IActionResult> DeleteDistritoAdmin(int scoutId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _permisosService.DeleteDistritoAdmin(userId, scoutId);
      return Ok(new { Message = "Administrador eliminado" });
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

