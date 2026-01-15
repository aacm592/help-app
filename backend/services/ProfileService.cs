using AutoMapper;
using backend.data.models.profile;
using backend.dtos.request.profile;
using backend.dtos.responses.profile;
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;

public class ProfileService: IProfileService
{
  private readonly IProfileRepository _profileRepository;
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;

  public ProfileService(IProfileRepository profileRepository, IUserRepository userRepository, IMapper mapper)
  {
    _profileRepository = profileRepository;
    _userRepository = userRepository;
    _mapper = mapper;
  }

  public async Task<ScoutProfileResponseDto> GetScoutProfile(int userId)
  {
    var user = await _userRepository.GetByIdAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");
    
    var profile = await _profileRepository.GetScoutProfile(userId);
    
    if (profile == null)
      throw new ApplicationException("Profile no encontrado.");
    
    if (profile.ScoutProfile == null)
    {
      profile.ScoutProfile = new ScoutProfile();
      await _profileRepository.Update();
    }
    
    var response = _mapper.Map<ScoutProfileResponseDto>(profile);
    
    return response;
  }

  public async Task<ScoutProfileResponseDto> GetScoutProfile(int scoutId, int diriId)
  {
    var diri = await _userRepository.GetByIdAsync(diriId);
    var scout = await _userRepository.GetByIdAsync(scoutId);
    
    if (scout == null)
      throw new ApplicationException("Scout no encontrado.");
    
    if (diri == null)
      throw new ApplicationException("Dirigente no encontrado.");

    var scoutUnidad = scout.Unidades.First();
    var diriUnidad = diri.Unidades;
    
    if (scoutUnidad == null)
      throw new ApplicationException("El scout no está en una unidad.");

    if (!diriUnidad.Any(u => u.Id == scoutUnidad.Id))
      throw new ApplicationException("No estás en la unidad del scout.");

    return await GetScoutProfile(scoutId);
  }

  public async Task<DiriProfileResponseDto?> GetDiriProfile(int userId)
  {
    var user = await _userRepository.GetByIdAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");
    
    var profile = await _profileRepository.GetDiriProfile(userId);
    
    if (profile == null)
      throw new ApplicationException("Profile no encontrado.");
    
    if (profile.DiriProfile == null)
    {
      profile.DiriProfile = new DiriProfile();
      await _profileRepository.Update();
    }
    
    var response = _mapper.Map<DiriProfileResponseDto>(profile);
    
    return response;  }

  public async Task UpdateScoutProfile(ScoutProfileRequestDto newProfile, int scoutId)
  {
    var user = await _userRepository.GetByIdAsync(scoutId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");
    
    var profile = await _profileRepository.GetScoutProfile(scoutId);
    
    if (profile == null)
      throw new ApplicationException("Profile no encontrado.");
    
    if (profile.ScoutProfile == null)
      profile.ScoutProfile = new ScoutProfile();
    
    _mapper.Map(newProfile, profile);
    
    await _profileRepository.Update();
  }

  public async Task UpdateScoutProfile(ScoutProfileRequestDto profile, int scoutId, int diriId)
  {
    var diri = await _userRepository.GetByIdAsync(diriId);
    var scout = await _userRepository.GetByIdAsync(scoutId);
    
    if (scout == null)
      throw new ApplicationException("Scout no encontrado.");
    
    if (diri == null)
      throw new ApplicationException("Dirigente no encontrado.");

    var scoutUnidad = scout.Unidades.First();
    var diriUnidad = diri.Unidades;
    
    if (scoutUnidad == null)
      throw new ApplicationException("El scout no está en una unidad.");

    if (!diriUnidad.Any(u => u.Id == scoutUnidad.Id))
      throw new ApplicationException("No estás en la unidad del scout.");
    
    await UpdateScoutProfile(profile, scoutId);
  }

  public async Task UpdateDiriProfile(DiriProfileRequestDto newProfile, int scoutId)
  {
    var user = await _userRepository.GetByIdAsync(scoutId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado.");
    
    var profile = await _profileRepository.GetDiriProfile(scoutId);
    
    if (profile == null)
      throw new ApplicationException("Profile no encontrado.");
    
    if (profile.DiriProfile == null)
      profile.DiriProfile = new DiriProfile();
    
    _mapper.Map(newProfile, profile);
    
    await _profileRepository.Update();
  }
}
