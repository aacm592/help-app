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
        $"{src.Profile!.Nombre} {src.Profile.Apellido}"))
      .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Tipo.Nombre))
      .ForMember(dest => dest.Edad, opt => opt.MapFrom(src => 
        DateTime.Today.Year - src.Profile!.FechaNacimiento.Year - 
        (DateTime.Today < src.Profile.FechaNacimiento.AddYears(DateTime.Today.Year - src.Profile.FechaNacimiento.Year) ? 1 : 0)));
    
  }
}