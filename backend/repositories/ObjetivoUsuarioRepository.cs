using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class ObjetivoUsuarioRepository : IObjetivoUsuarioRepository
{
  private readonly ScoutsAppContext _context;

  public ObjetivoUsuarioRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<ObjetivoUsuario> AddAsync(ObjetivoUsuario objetivoUsuario)
  {
    _context.ObjetivosUsuario.Add(objetivoUsuario);
    await _context.SaveChangesAsync();
    return objetivoUsuario;
  }

  public async Task<bool> ExistsAsync(int usuarioId, int objetivoId)
  {
    return await _context.ObjetivosUsuario
      .AnyAsync(ou => ou.UsuarioId == usuarioId && ou.ObjetivoEducativoId == objetivoId);
  }
}
