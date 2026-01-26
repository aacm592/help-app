using System.Security.Claims;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[Controller]
[Route("api/[controller]")]
public class RegistroControler: ControllerBase
{
  private readonly IRegistroService _registroService;

  public RegistroControler(IRegistroService registroService)
  {
    _registroService = registroService;
  }

  [Authorize(Roles = "2")]
  [Authorize(Roles = "p1, p2")]
  [HttpGet("/users/{scoutId}")]
  public async Task<IActionResult> GetUsers(int scoutId)
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
}
