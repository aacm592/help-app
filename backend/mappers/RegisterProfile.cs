using AutoMapper;
using backend.data.models;
using backend.data.models.registros;
using backend.dtos.registros;

namespace backend.mappers;

public class RegisterProfile : Profile
{
  public RegisterProfile()
  { 
    CreateMap<RegistroScout, ScoutInfoDto>()
      .ForMember(dest => dest.UnidadEducativa, opt => opt.MapFrom(src => src.UnidadEducativa))
      .ForMember(dest => dest.Curso, opt => opt.MapFrom(src => src.Curso))
      .ForMember(dest => dest.Etapa, opt => opt.MapFrom(src => src.Etapa));

    CreateMap<RegistroDiri, DiriInfoDto>()
      .ForMember(dest => dest.Profesion, opt => opt.MapFrom(src => src.Profesion))
      .ForMember(dest => dest.Ocupacion, opt => opt.MapFrom(src => src.Ocupacion))
      .ForMember(dest => dest.Cargo1, opt => opt.MapFrom(src => src.Cargo1))
      .ForMember(dest => dest.Cargo2, opt => opt.MapFrom(src => src.Cargo2));

    CreateMap<Registro, UserRegistrosDto<ScoutInfoDto>>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
      .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
      .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rama))
      .ForMember(dest => dest.Edad, opt => opt.MapFrom(src => 
         CalculateAge(src.FechaNacimiento)))
      .ForMember(dest => dest.Distrito, opt => opt.MapFrom(src => src.Distrito))
      .ForMember(dest => dest.Grupo, opt => opt.MapFrom(src => src.Grupo))
      .ForMember(dest => dest.RegistroStatus, opt => opt.MapFrom(src => src.Status.ToString()))
      .ForMember(dest => dest.Datos, opt => opt.MapFrom(src => src.RegistroScout));

    CreateMap<Registro, UserRegistrosDto<DiriInfoDto>>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
      .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
      .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rama))
      .ForMember(dest => dest.Edad, opt => opt.MapFrom(src => CalculateAge(src.FechaNacimiento)))
      .ForMember(dest => dest.Distrito, opt => opt.MapFrom(src => src.Distrito))
      .ForMember(dest => dest.Grupo, opt => opt.MapFrom(src => src.Grupo))
      .ForMember(dest => dest.RegistroStatus, opt => opt.MapFrom(src => src.Status.ToString()))
      .ForMember(dest => dest.Datos, opt => opt.MapFrom(src => src.RegistroDiri));

    CreateMap<Registro, RegistroDto>()
      .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
      .ForMember(dest => dest.GestionId, opt => opt.MapFrom(src => src.GestionId));
  }

    private static int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }
}
