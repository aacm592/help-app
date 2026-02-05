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

    CreateMap<Unidad, UnidadUsersDto>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
      .ForMember(dest => dest.Dirigentes, opt => opt.MapFrom(src => 
        src.Usuarios.Where(u => u.Profile!.DiriProfile != null)))
      .ForMember(dest => dest.Scouts, opt => opt.MapFrom(src => 
        src.Usuarios.Where(u => u.Profile!.ScoutProfile != null && u.Profile.DiriProfile == null)));
    
    CreateMap<Unidad, UnidadRegistrosDto>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
      .ForMember(dest => dest.Dirigentes, opt => opt.MapFrom(src => 
        src.Usuarios.Where(u => u.Profile!.DiriProfile != null).Select(u => u.Registros)))
      .ForMember(dest => dest.Scouts, opt => opt.MapFrom(src => 
        src.Usuarios.Where(u => u.Profile!.ScoutProfile != null && u.Profile.DiriProfile == null).Select(u => u.Registros)));
  }
}
