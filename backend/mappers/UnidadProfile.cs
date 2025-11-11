using AutoMapper;
using backend.data.models;
using backend.dtos.responses;

namespace backend.mappers;

public class UnidadProfile: Profile
{
  public UnidadProfile()
  {
    CreateMap<Unidad, UnidadResponseDto>()
      .ForMember(dest => dest.RamaNombre, 
        opt => opt.MapFrom(src => src.Rama.Nombre))
      .ForMember(dest => dest.GrupoScoutNombre, 
        opt => opt.MapFrom(src => src.GrupoScout.Nombre));
  }
}
