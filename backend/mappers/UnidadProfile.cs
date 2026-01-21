using AutoMapper;
using backend.data.models;
using backend.dtos.registros;
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

    CreateMap<Unidad, GrupoUnidadesResponseDto>()
      .ForMember(dest => dest.Nombre,
        opt => opt.MapFrom(src => src.Nombre))
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.Usuarios, opt => opt.MapFrom(src => src.Usuarios));
  }
}
