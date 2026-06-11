using AutoMapper;
using backend.data.models;
using backend.dtos.responses;

namespace backend.mappers;

public class ObjetivoEducativoProfile : Profile
{
  public ObjetivoEducativoProfile()
  {
    CreateMap<ObjetivoEducativo, ObjetivoEducativoDto>()
      .ForMember(dest => dest.AreaCrecimientoNombre,
        opt => opt.MapFrom(src => src.AreaCrecimiento.Nombre));
  }
}
