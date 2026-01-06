using backend.data;
using backend.data.models.especialidades;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class EspecialidadRepository: IEspecialidadRepository
{
  
  private readonly ScoutsAppContext _context;

  public EspecialidadRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Especialidad>> GetEspecialidadesByRama(int rama)
  {
    var especialidades = await _context.Especialidades
      .Include(e => e.Requisitos)
      .ThenInclude(x => x.RequisitosEspUser)
      .Where(e => e.RamaId == rama)
      .ToListAsync();
    return especialidades;
  }
}
