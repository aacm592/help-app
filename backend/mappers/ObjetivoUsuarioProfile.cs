using AutoMapper;
using backend.data.models;
using backend.dtos.responses;

namespace backend.mappers;

public class ObjetivoUsuarioProfile : Profile
{
  public ObjetivoUsuarioProfile()
  {
    CreateMap<ObjetivoUsuario, ObjetivoUsuarioResponseDto>()
      .ForMember(dest => dest.ObjetivoId, opt => opt.MapFrom(src => src.ObjetivoEducativoId))
      .ForMember(dest => dest.ObjetivoDescripcion, opt => opt.MapFrom(src => src.ObjetivoEducativo!.Descripcion))
      .ForMember(dest => dest.AreaNombre, opt => opt.MapFrom(src => src.ObjetivoEducativo!.AreaCrecimiento.Nombre))
      .ForMember(dest => dest.FechaSeleccion, opt => opt.MapFrom(src => src.FechaSeleccion))
      .ForMember(dest => dest.FechaAprobacion, opt => opt.MapFrom(src => src.FechaAprobacion))
      .ForMember(dest => dest.DirigenteAproboId, opt => opt.MapFrom(src => src.DirigenteAproboId))
      .ForMember(dest => dest.DirigenteAproboNombre, opt => opt.MapFrom(
        src => src.DirigenteAprobo == null || src.DirigenteAprobo.Profile == null 
          ? null 
          : src.DirigenteAprobo.Profile.Nombre));
    
    CreateMap<ObjetivoUsuario, PendingObjetivoDto>()
      .ForMember(dest => dest.NombreScout, opt => opt.MapFrom(src => src.User.Profile == null ? "" : src.User.Profile.Nombre))
      .ForMember(dest => dest.ObjetivoId, opt => opt.MapFrom(src => src.ObjetivoEducativoId))
      .ForMember(dest => dest.ObjetivoDescripcion, opt => opt.MapFrom(src => src.ObjetivoEducativo!.Descripcion))
      .ForMember(dest => dest.AreaNombre, opt => opt.MapFrom(src => src.ObjetivoEducativo!.AreaCrecimiento.Nombre))
      .ForMember(dest => dest.FechaSeleccion, opt => opt.MapFrom(src => src.FechaSeleccion));
  }
}
