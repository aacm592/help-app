using AutoMapper;
using backend.data.models;
using backend.dtos.responses;

namespace backend.mappers;

public class AuthProfile: Profile
{
  public AuthProfile()
  {
    CreateMap<User, UserResponseDto>()
      .ForMember(dest => dest.Unidades, opt => opt.MapFrom(src => src.Unidades));
  }
}
