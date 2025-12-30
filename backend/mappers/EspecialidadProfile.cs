using AutoMapper;
using backend.data.models.especialidades;
using backend.dtos.responses.especialidades;

namespace backend.mappers;

public class EspecialidadProfile : Profile
{
  public EspecialidadProfile()
  {
    CreateMap<RequisitoEsp, EspecialidadReqDto>()
      .ForMember(d => d.Status, opt => opt.Ignore());

    CreateMap<Especialidad, EspecialidadDto>()
      .ForMember(d => d.IdEspecialidad, opt => opt.MapFrom(s => s.Id))
      .ForMember(d => d.Requerimientos, opt => opt.MapFrom(s => s.Requisitos))
      .ForMember(d => d.Status, opt => opt.Ignore());

    CreateMap<RequisitoEspUser, UserRequisitoEspDto>()
      .ForMember(d => d.ScoutId, opt => opt.MapFrom(s => s.UsuarioId))
      .ForMember(d => d.ScoutNombre, opt => opt.MapFrom(s => s.Usuario.Profile != null ? s.Usuario.Profile.Nombre : string.Empty))
      .ForMember(d => d.RequerimientoId, opt => opt.MapFrom(s => s.Requisito.Id))
      .ForMember(d => d.Especialidad, opt => opt.MapFrom(s=> s.Requisito.Especialidad.Nombre))
      .ForMember(d => d.Descripcion, opt => opt.MapFrom(s => s.Requisito.Descripcion));
  }
}
