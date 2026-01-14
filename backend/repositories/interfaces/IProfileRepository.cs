using backend.data.models.profile;

namespace backend.repositories.interfaces;

public interface IProfileRepository
{
  public Task<UserProfile?> GetScoutProfile(int userId);
  public Task<UserProfile?> GetDiriProfile(int userId);
  public Task Update();
}
