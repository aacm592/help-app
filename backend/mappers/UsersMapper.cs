using AutoMapper;
using backend.data.models;
using backend.dtos.registros;

namespace backend.mappers;

public class UsersMapper: Profile
{
  public UsersMapper()
  {
    CreateMap<User, UserDataDto>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => 
        src.Profile != null ? $"{src.Profile.Nombre} {src.Profile.Apellido}" : "Sin Nombre"))
      .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Tipo.Nombre))
      .ForMember(dest => dest.Edad, opt => opt.MapFrom(src => 
        src.Profile != null ? CalculateAge(src.Profile.FechaNacimiento) : 0))
      .ForMember(dest => dest.Distrito, opt => opt.MapFrom(src => 
        src.Registros.FirstOrDefault() != null ? src.Registros.FirstOrDefault()!.Distrito : "N/A"))
      .ForMember(dest => dest.Grupo, opt => opt.MapFrom(src => 
        src.Registros.FirstOrDefault() != null ? src.Registros.FirstOrDefault()!.Grupo : "N/A"))
      .ForMember(dest => dest.RegistroStatus, opt => opt.MapFrom(src => 
        src.Registros.FirstOrDefault() != null ? src.Registros.FirstOrDefault()!.Status.ToString() : "No registrado"));
  }

  private static int CalculateAge(DateTime birthDate)
  {
    var today = DateTime.Today;
    var age = today.Year - birthDate.Year;
    if (birthDate.Date > today.AddYears(-age)) age--;
    return age;
  }
}