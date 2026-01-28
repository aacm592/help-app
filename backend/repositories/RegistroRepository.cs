using backend.data;
using backend.data.models.registros;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class RegistroRepository: IRegistroRepository
{
  private readonly ScoutsAppContext _context;

  public RegistroRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<Registro> Create(Registro registro)
  {
    await _context.Registros.AddAsync(registro);
    await Update();
    return registro;
  }

  public async Task Update()
  {
    await _context.SaveChangesAsync();
  }

  public async Task<Registro?> GetRegistroByUserId(int userId, int gestionId)
  {
    return await _context.Registros.FirstOrDefaultAsync(x => x.UserId == userId && x.GestionId == gestionId);
  }

  public async Task Delete(Registro registro)
  {
    _context.Registros.Remove(registro);
    await Update();
  }
}
