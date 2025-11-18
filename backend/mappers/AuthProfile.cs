using AutoMapper;
using backend.data.models;
using backend.dtos.responses;

namespace backend.mappers;

public class AuthProfile: Profile
{
  public AuthProfile()
  {
    CreateMap<User, UserResponseDto>()
      .ForMember(dest => dest.Nombre, 
        opt => opt.MapFrom(src => src.Profile != null ? src.Profile.Nombre : string.Empty)) 
      .ForMember(dest => dest.FechaNacimiento, 
        opt => opt.MapFrom(src => src.Profile != null ? src.Profile.FechaNacimiento : default(DateTime)))
      
      .ForMember(dest => dest.Unidades, 
        opt => opt.MapFrom(src => src.Unidades));
  }
}
