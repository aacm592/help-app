using System.Globalization;
using backend.data.models;
using CsvHelper;
using CsvHelper.Configuration;

namespace backend.data.seeders;

public static class GrupoScoutCsvSeeder
{
  private const string FileName = "Grupos2025.csv";
    
  public static List<GrupoScout> GetData() { 
    var grupos = new List<GrupoScout>();
        
    var filePath = Path.Combine(AppContext.BaseDirectory, FileName);

    if (!File.Exists(filePath))
      return grupos; 

    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    { 
      HeaderValidated = null,
      MissingFieldFound = null,
      TrimOptions = TrimOptions.Trim,
    };

    try
    {
      using var reader = new StreamReader(filePath);
      using var csv = new CsvReader(reader, config);
            
      var records = csv.GetRecords<dynamic>().ToList();
            
      foreach (var record in records)
      { 
        var grupo = new GrupoScout
        { 
          Id = int.Parse((string)record.Id),
          Nombre = (string)record.Nombre,
          DistritoId = int.Parse((string)record.DistritoId)
        };
        grupos.Add(grupo);
      }
    }
    catch (Exception ex)
    { 
      throw new ApplicationException($"Error al leer el CSV de grupos durante el seeding. Mensaje: {ex.Message}", ex);
    }
    return grupos;
  }
}
