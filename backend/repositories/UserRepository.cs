using backend.data;
using backend.data.models;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ScoutsAppContext _context;

    public UserRepository(ScoutsAppContext context)
    {
      _context = context;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
      return await _context.Users
        .FirstOrDefaultAsync(u => u.NombreUsuario == username);
    }

    public async Task<User> AddAsync(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync(); 
      return user;
    }
    
    public async Task<User?> GetByIdAsync(int id)
    {
      return await _context.Users
        .Include(u => u.Unidades)
        .FirstOrDefaultAsync(u => u.Id == id);
    }
  }
}
