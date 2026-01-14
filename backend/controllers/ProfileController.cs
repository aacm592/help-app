using System.Security.Claims;
using backend.dtos.request.profile;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProfileController: ControllerBase
{
  private readonly IProfileService _profileService;

  public ProfileController(IProfileService profileService)
  {
    _profileService = profileService;
  }
  
  [Authorize(Roles = "1")]
  [HttpGet("scout")]
  public async Task<IActionResult> GetScoutProfile()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var resultado = await _profileService.GetScoutProfile(userId);

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
  [HttpGet("scout/{scoutId}")]
  public async Task<IActionResult> GetScoutProfile(int scoutId)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var resultado = await _profileService.GetScoutProfile(scoutId, userId);

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
  
  [Authorize(Roles = "1")]
  [HttpPut("scout")]
  public async Task<IActionResult> UpdateScoutProfile(ScoutProfileRequestDto dto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _profileService.UpdateScoutProfile(dto, userId);

      return Ok(new { Message = "Perfil actualizado exitósamente." });
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
  [HttpPut("scout/{scoutId}")]
  public async Task<IActionResult> UpdateScoutProfile(int scoutId, ScoutProfileRequestDto dto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _profileService.UpdateScoutProfile(dto, scoutId, userId);

      return Ok(new { Message = "Perfil actualizado exitósamente." });
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
  [HttpGet("diri")]
  public async Task<IActionResult> GetDiriProfile()
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      var resultado = await _profileService.GetDiriProfile(userId);

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
  [HttpPut("diri")]
  public async Task<IActionResult> UpdateDiriProfile(DiriProfileRequestDto dto)
  {
    try
    {
      var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(userIdString, out var userId))
        return Unauthorized("Token de usuario inválido.");

      await _profileService.UpdateDiriProfile(dto, userId);

      return Ok(new { Message = "Perfil actualizado exitósamente." });
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
