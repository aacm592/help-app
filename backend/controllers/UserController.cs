using System.Security.Claims;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserService _userService;
  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [Authorize(Roles = "1")]
  [HttpPost("to-diri")]
  public async Task<IActionResult> GenerateResetCode()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _userService.ChangeUserToDiri(userId);
      return Ok(new { Message = "Ahora eres dirigente" });
    }
    catch (ApplicationException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Ocurrió un error interno: {ex.Message}");
    }
  }
}