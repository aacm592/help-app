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
  }
}
