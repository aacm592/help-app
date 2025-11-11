using AutoMapper;
using backend.data.models;
using backend.dtos.responses;

namespace backend.mappers;

public class CatalogProfile : Profile
{
  public CatalogProfile()
  {
    CreateMap<Rama, CatalogDto>();
    CreateMap<GrupoScout, CatalogDto>();
    CreateMap<Distrito, CatalogDto>();
    CreateMap<EtapaProgresion, CatalogDto>();
  }
}
