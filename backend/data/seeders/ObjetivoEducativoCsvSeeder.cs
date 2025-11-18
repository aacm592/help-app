using System.Globalization;
using backend.data.models;
using CsvHelper;
using CsvHelper.Configuration;

namespace backend.data.seeders;

public static class ObjetivoEducativoCsvSeeder
{
  private const string FileName = "Objetivos.csv";
    
  public static List<ObjetivoEducativo> GetData() { 
    var objetivos = new List<ObjetivoEducativo>();
        
    var filePath = Path.Combine(AppContext.BaseDirectory, FileName);

    if (!File.Exists(filePath))
      return objetivos; 

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
        var objetivo = new ObjetivoEducativo
        { 
          Id = int.Parse((string)record.Id),
          Descripcion = (string)record.Descripcion,
          AreaCrecimientoId = int.Parse((string)record.AreaCrecimientoId),
          EtapaProgresionId = int.Parse((string)record.EtapaProgresionId)
        };
        objetivos.Add(objetivo);
      }
    }
    catch (Exception ex)
    { 
      throw new ApplicationException($"Error al leer el CSV de objetivos durante el seeding. Mensaje: {ex.Message}", ex);
    }
    return objetivos;
  }
}
