using backend.dtos.request.profile;
using backend.dtos.responses.profile;

namespace backend.services.interfaces;

public interface IProfileService
{
  public Task<ScoutProfileResponseDto> GetScoutProfile(int userId);
  public Task<ScoutProfileResponseDto> GetScoutProfile(int scoutId, int diriId);
  public Task<DiriProfileResponseDto?> GetDiriProfile(int userId);
  public Task UpdateScoutProfile(ScoutProfileRequestDto profile, int scoutId);
  public Task UpdateScoutProfile(ScoutProfileRequestDto profile, int scoutId, int diriId);
  public Task UpdateDiriProfile(DiriProfileRequestDto profile, int scoutId);
}
