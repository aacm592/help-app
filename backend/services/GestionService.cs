using backend.data.models.registros;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class GestionService: IGestionService
{
  private readonly IGestionRepository _gestionRepository;

  public GestionService(IGestionRepository gestionRepository)
  {
    _gestionRepository = gestionRepository;
  }

  public async Task CrearGestion(int year)
  {
    var gestionActual = await _gestionRepository.GetGestionActual();
    
    if (gestionActual != null)
      throw new ApplicationException("Hay una gestión activa actualmente");

    var gestion = new Gestion()
    {
      Active = true,
      Year = year
    };
    
    await _gestionRepository.CreateGestion(gestion);
  }
}
