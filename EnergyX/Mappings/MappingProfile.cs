using AutoMapper;
using EnergyX.DTOs;
using EnergyX.Models;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Reatores, ReatoresDto>();

    CreateMap<CreateRelatoriosTurnoDto, RelatoriosTurno>();
    CreateMap<UpdateRelatoriosTurnoDto, RelatoriosTurno>();
    CreateMap<RelatoriosTurno, RelatoriosTurnoDto>();

    CreateMap<CreateOperadoresDto, Operadores>();
    CreateMap<Operadores, OperadoresDto>();
  }
}
