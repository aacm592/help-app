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

  public async Task<RequisitoEspUser> Add(RequisitoEspUser requisitoEspUser)
  {
    await _context.RequisitoEspUsers.AddAsync(requisitoEspUser);
    await _context.SaveChangesAsync();
    return requisitoEspUser;
  }

  public async Task<RequisitoEspUser> UpdateReqEspUser(RequisitoEspUser requisitoEspUser)
  {
    _context.RequisitoEspUsers.Update(requisitoEspUser);
    await _context.SaveChangesAsync();
    return requisitoEspUser;
  }


  public async Task<RequisitoEsp?> GetRequisito(int id)
  {
    return await _context.RequisitosEsp
      .Include(x => x.Especialidad)
      .FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<RequisitoEspUser?> GetRequisitoByUserIdAndRequisitoId(int userId, int requisitoId)
  {
    return await _context.RequisitoEspUsers
      .FirstAsync(x => x.UsuarioId == userId && x.RequisitoId == requisitoId);
  }
}
