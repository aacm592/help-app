
using backend.repositories.interfaces;
using backend.services.interfaces;

namespace backend.services;
public class UserService : IUserService
{

  private readonly IUserRepository _userRepository;

  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task ChangeUserToDiri(int userId)
  {
    var user = await _userRepository.GetByIdAsync(userId);
    if (user == null)
      throw new ApplicationException("Usuario no encontrado");

    if (user.TipoId == 2)
      throw new ApplicationException("Ya eres dirigente");

    var age = CalculateAge(user.Profile!.FechaNacimiento);

    if (age < 18)
      throw new ApplicationException("Debes tener al menos 18 años de edad para ser dirigente");

    user.TipoId = 2;

    await _userRepository.UpdateAsync(user);

    return;
  }

  private static int CalculateAge(DateTime dateOfBirth)
  {
    var birthDateUtc = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc);
    var today = DateTime.UtcNow;
    var age = today.Year - birthDateUtc.Year;
    if (birthDateUtc.Date > today.AddYears(-age)) age--;
    return age;
  }
}