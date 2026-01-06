using System.Globalization;
using backend.data.models.especialidades;
using CsvHelper;
using CsvHelper.Configuration;

namespace backend.data.seeders;

public class EspecialidadesCsvSeeder
{
  private const string FileName = "Especialidades.csv";

  public static List<Especialidad> GetData()
  {
    var especialidades = new List<Especialidad>();

    var filePath = Path.Combine(AppContext.BaseDirectory, FileName);

    if (!File.Exists(filePath))
      return especialidades;


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
          var objetivo = new Especialidad()
          { 
            Id = int.Parse((string)record.Id),
            Descripcion = (string)record.Descripcion,
            Nombre = (string)record.Nombre,
            RamaId =  int.Parse((string)record.RamaId),
          };
          especialidades.Add(objetivo);
        }      
    }
    catch (Exception ex)
    {
      throw new ApplicationException($"Error al leer el CSV de especialidades durante el seeding. Mensaje: {ex.Message}", ex);
    }
    
    return especialidades;
  }
}
