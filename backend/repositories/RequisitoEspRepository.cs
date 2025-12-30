using backend.data;
using backend.data.models.especialidades;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class RequisitoEspRepository: IRequisitoEspRepository
{
  private readonly ScoutsAppContext _context;

  public RequisitoEspRepository(ScoutsAppContext context)
  {
    _context = context;
  }
  
  public async Task<IEnumerable<RequisitoEspUser>> GetRequisitosByUser(int userId)
  {
    return await _context.RequisitoEspUsers
      .Include(x => x.Requisito)
      .Where(x => x.UsuarioId == userId)
      .ToListAsync();
  }

  public async Task<IEnumerable<RequisitoEsp>> GetRequisitosByEspecialidad(int especialidadId)
  {
    return await _context.RequisitosEsp
      .Where(x => x.EspecialidadId == especialidadId)
      .ToListAsync();
  }
}
