using AutoMapper;
using backend.data.models;
using backend.dtos.responses;

namespace backend.mappers;

public class UnidadProfile: Profile
{
  public UnidadProfile()
  {
    CreateMap<Unidad, UnidadResponseDto>();
  }
}