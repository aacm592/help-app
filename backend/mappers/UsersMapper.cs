using AutoMapper;
using backend.data.models;
using backend.data.models.profile;
using backend.data.models.registros;
using backend.dtos.registros;

namespace backend.mappers;

public class UsersMapper: Profile
{
  public UsersMapper()
  { 
    CreateMap<ScoutProfile, ScoutInfoDto>()
      .ForMember(dest => dest.UnidadEducativa, opt => opt.MapFrom(src => src.UnidadEducativa))
      .ForMember(dest => dest.Curso, opt => opt.MapFrom(src => src.Curso))
      .ForMember(dest => dest.Etapa, opt => opt.MapFrom(src => src.Etapa));

    CreateMap<DiriProfile, DiriInfoDto>()
      .ForMember(dest => dest.Profesion, opt => opt.MapFrom(src => src.Profesion))
      .ForMember(dest => dest.Ocupacion, opt => opt.MapFrom(src => src.Ocupacion))
      .ForMember(dest => dest.Cargo1, opt => opt.MapFrom(src => src.Cargo1))
      .ForMember(dest => dest.Cargo2, opt => opt.MapFrom(src => src.Cargo2));

    CreateMap<User, UserDataDto<DiriInfoDto>>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => 
        src.Profile != null ? $"{src.Profile.Nombre} {src.Profile.Apellido}" : "Sin Nombre"))
      .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Tipo.Nombre))
      .ForMember(dest => dest.Edad, opt => opt.MapFrom(src => 
        src.Profile != null ? CalculateAge(src.Profile.FechaNacimiento) : 0))
      .ForMember(dest => dest.RegistroStatus, opt => opt.MapFrom(src => 
        src.Registros.FirstOrDefault() != null ? src.Registros.FirstOrDefault()!.Status.ToString() : "No registrado"))
      .ForMember(dest => dest.Datos, opt => opt.MapFrom(src => src.Profile!.DiriProfile));
    
    CreateMap<User, UserDataDto<ScoutInfoDto>>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => 
        src.Profile != null ? $"{src.Profile.Nombre} {src.Profile.Apellido}" : "Sin Nombre"))
      .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Tipo.Nombre))
      .ForMember(dest => dest.Edad, opt => opt.MapFrom(src => 
        src.Profile != null ? CalculateAge(src.Profile.FechaNacimiento) : 0))
      .ForMember(dest => dest.RegistroStatus, opt => opt.MapFrom(src => 
        src.Registros.FirstOrDefault() != null ? src.Registros.FirstOrDefault()!.Status.ToString() : "No registrado"))
      .ForMember(dest => dest.Datos, opt => opt.MapFrom(src => src.Profile!.ScoutProfile));

  }

    private static int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }
}
