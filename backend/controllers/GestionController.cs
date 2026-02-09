using backend.repositories.interfaces;
using backend.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Authorize]
[Controller]
[Route("api/[controller]")]
public class GestionController: ControllerBase
{
  private readonly IGestionService _gestionService;

  public GestionController(IGestionService gestionService)
  {
    _gestionService = gestionService;
  }
  
  [HttpPost("create/{year}")]
  public async Task<IActionResult> Register(int year)
  {
    try
    { 
      await _gestionService.CrearGestion(year); 
      return Ok(new { Message = "Gestion creada." });
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
}
