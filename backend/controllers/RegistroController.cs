using System.Security.Claims;
using backend.dtos.auth;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[Controller]
[Route("api/[controller]")]
public class RegistroController: ControllerBase
{
  private readonly IRegistroService _registroService;

  public RegistroController(IRegistroService registroService)
  {
    _registroService = registroService;
  }

  [Authorize(Roles = "2")]
  [Authorize(Roles = "p1, p2")]
  [HttpPost("grupo/user")]
  public async Task<IActionResult> RegisterUserToGroup([FromBody] IdDto scoutId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _registroService.RegisterUserToGroup(scoutId, userId);
      return Ok(new { Message = "Usuario registrado correctamente." });
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
  [Authorize(Roles = "p1, p2")]
  [HttpDelete("grupo/user")]
  public async Task<IActionResult> DeleteRegisterUserToGroup([FromBody] IdDto scoutId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _registroService.CancelRegisterToGroup(scoutId, userId);
      return Ok(new { Message = "Registro cancelado correctamente." });
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
