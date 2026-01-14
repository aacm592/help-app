using AutoMapper;
using backend.data.models.profile;
using backend.dtos.request.profile;
using backend.dtos.responses.profile;

namespace backend.mappers;

public class ProfileProfile : Profile
{
  public ProfileProfile()
  {
    CreateMap<UserProfile, ScoutProfileResponseDto>()
      .ForMember(dest => dest.Curso,
        opt => opt.MapFrom(src => src.ScoutProfile != null ? src.ScoutProfile.Curso : "Sin curso"))
      .ForMember(dest => dest.UnidadEducativa,
        opt => opt.MapFrom(src =>
          src.ScoutProfile != null ? src.ScoutProfile.UnidadEducativa : "Sin Unidad Educativa"));
      
    CreateMap<UserProfile, DiriProfileResponseDto>()
      .ForMember(dest => dest.Ocupacion,
        opt => opt.MapFrom(src => src.DiriProfile != null ? src.DiriProfile.Ocupacion : "Sin Ocupacion"))
      .ForMember(dest => dest.Profesion,
        opt => opt.MapFrom(src => src.DiriProfile != null ? src.DiriProfile.Profesion : "Sin Profesion"));
    
    CreateMap<ScoutProfileRequestDto, UserProfile>()
      .ForPath(dest => dest.ScoutProfile!.Curso, opt => opt.MapFrom(src => src.Curso))
      .ForPath(dest => dest.ScoutProfile!.UnidadEducativa, opt => opt.MapFrom(src => src.UnidadEducativa));

    CreateMap<DiriProfileRequestDto, UserProfile>()
      .ForPath(dest => dest.DiriProfile!.Ocupacion, opt => opt.MapFrom(src => src.Ocupacion))
      .ForPath(dest => dest.DiriProfile!.Profesion, opt => opt.MapFrom(src => src.Profesion));
  }
}
