using backend.data;
using backend.data.models.profile;
using backend.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.repositories;

public class ProfileRepository: IProfileRepository
{
  private readonly ScoutsAppContext _context;

  public ProfileRepository(ScoutsAppContext context)
  {
    _context = context;
  }

  public async Task<UserProfile?> GetScoutProfile(int userId)
  {
    return await _context.UserProfiles
      .Include(u => u.ScoutProfile)
      .FirstOrDefaultAsync(x => x.Id == userId);
  }

  public async Task<UserProfile?> GetDiriProfile(int userId)
  {
    return await _context.UserProfiles
      .Include(u => u.DiriProfile)
      .FirstOrDefaultAsync(x => x.Id == userId);
  }

  public async Task Update()
  {
    await _context.SaveChangesAsync();
  }
}
