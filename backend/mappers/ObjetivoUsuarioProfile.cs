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
      .ForMember(dest => dest.ObjetivoDescripcion, opt => opt.MapFrom(src => src.ObjetivoEducativo.Descripcion));
  }
}
