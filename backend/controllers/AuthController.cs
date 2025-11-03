using backend.dtos.auth;
using backend.services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IAuthService _authService;

  public AuthController(IAuthService authService)
  {
    _authService = authService;
  }
  
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
  {
    try
    {
      var userResponse = await _authService.RegisterAsync(registerDto);
      return Ok(userResponse);
    }
    catch (ApplicationException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
      return StatusCode(500, 
        $"Error: {ex.Message} --- INNER EXCEPTION: {ex.InnerException?.Message}");    }
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
  {
    try
    {
      var loginResponse = await _authService.LoginAsync(loginDto);
      return Ok(loginResponse);
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