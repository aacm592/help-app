using AutoMapper;
using backend.data.models;
using backend.dtos.responses;

namespace backend.mappers;

public class PermisoProfile: Profile
{
  public PermisoProfile()
  {
    CreateMap<UserPermiso, PermisoResponseDto>()
      .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.PermisoId))
      .ForMember(dst => dst.Nombre, opt => opt.MapFrom(src => src.Permiso.Nombre))
      .ForMember(dst => dst.AreaId, opt => opt.MapFrom(src => src.Distrito == null ? src.GrupoScoutId : src.Distrito.Id));
  }
}
