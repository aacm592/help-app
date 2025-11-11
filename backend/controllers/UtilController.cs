using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using backend.data;
using backend.data.models;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace backend.controllers;

[Authorize(Roles = "2")]
[ApiController]
[Route("api/[controller]")]
public class UtilController : ControllerBase
{ 
  private readonly ScoutsAppContext _context;
  
  public UtilController(ScoutsAppContext context)
  {
    _context = context;
  }

  [HttpPost("upload-objetivos")]
  public async Task<IActionResult> UploadObjetivos(IFormFile file)
  {
    if (file == null || file.Length == 0)
    {
      return BadRequest("No se ha subido ningún archivo.");
    }

    var tableName = _context.Model.FindEntityType(typeof(ObjetivoEducativo))
      .GetTableName();
            
    var truncateSql = $"TRUNCATE TABLE \"{tableName}\" RESTART IDENTITY CASCADE";
        
    await using var transaction = await _context.Database.BeginTransactionAsync();
    try
    {
      await _context.Database.ExecuteSqlRawAsync(truncateSql);
      var objetivos = new List<ObjetivoEducativo>();
            
      var config = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        HeaderValidated = null,
        MissingFieldFound = null,
        TrimOptions = TrimOptions.Trim,
      };

      using (var reader = new StreamReader(file.OpenReadStream()))
      using (var csv = new CsvReader(reader, config))
      {
        var records = csv.GetRecords<dynamic>();

        foreach (var record in records)
        {
          // Leemos los nombres de columna actualizados del CSV
          var id = int.Parse((string)record.Id);
          var areaCrecimientoId = int.Parse((string)record.AreaCrecimientoId); // <-- CAMBIADO
          var descripcion = (string)record.Descripcion;
          var etapaProgresionId = int.Parse((string)record.EtapaProgresionId);
          var objetivo = new ObjetivoEducativo
          {
            Id = id, 
            Descripcion = descripcion,
            AreaCrecimientoId = areaCrecimientoId,
            EtapaProgresionId = etapaProgresionId
          };
          objetivos.Add(objetivo);
        }
      }

      _context.ChangeTracker.AutoDetectChangesEnabled = false;
      await _context.ObjetivosEducativos.AddRangeAsync(objetivos);
      await _context.SaveChangesAsync();
      _context.ChangeTracker.AutoDetectChangesEnabled = true;
      await transaction.CommitAsync();

      return Ok(new { Message = $"Éxito: Se cargaron {objetivos.Count} objetivos." });
    }
    catch (Exception ex)
    { 
      await transaction.RollbackAsync();
      return StatusCode(500, $"Error al procesar el archivo: {ex.Message}\nInner: {ex.InnerException?.Message}");
    }
  }
}
