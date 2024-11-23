using EnergyX.DTOs;
using EnergyX.Repositories.Interfaces;
using AutoMapper;
using EnergyX.Models;
using OdontoFast.Exceptions;

namespace EnergyX.Services
{
  public class RelatoriosTurnoService : IRelatoriosTurnoService
  {
    private readonly IRelatoriosTurnoRepository _repository;
    private readonly IMapper _mapper;

    public RelatoriosTurnoService(IRelatoriosTurnoRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<RelatoriosTurnoDto> CreateRelatorioTurnoAsync(CreateRelatoriosTurnoDto dto)
    {
      var relatorio = _mapper.Map<RelatoriosTurno>(dto);
      await _repository.AddAsync(relatorio);
      return _mapper.Map<RelatoriosTurnoDto>(relatorio);
    }

    public async Task<RelatoriosTurnoDto> GetRelatorioTurnoByIdAsync(long id)
    {
      var relatorio = await _repository.GetByIdAsync(id);
      if (relatorio == null)
        throw new NotFoundException("Relatório de turno não encontrado.");

      return _mapper.Map<RelatoriosTurnoDto>(relatorio);
    }

    public async Task<IEnumerable<RelatoriosTurnoDto>> GetAllRelatoriosTurnoAsync(int pageNumber, int pageSize)
    {
      var relatorios = await _repository.GetAllAsync();
      return relatorios.Skip((pageNumber - 1) * pageSize).Take(pageSize)
          .Select(o => _mapper.Map<RelatoriosTurnoDto>(o));
    }


    public async Task<RelatoriosTurnoDto> UpdateRelatorioTurnoAsync(long id, UpdateRelatoriosTurnoDto dto)
    {
      var relatorio = await _repository.GetByIdAsync(id);
      if (relatorio == null)
        throw new NotFoundException("Relatório de turno não encontrado.");


      _mapper.Map(dto, relatorio);
      await _repository.UpdateAsync(relatorio);
      return _mapper.Map<RelatoriosTurnoDto>(relatorio);
    }

    public async Task DeleteRelatorioTurnoAsync(long id)
    {
      var relatorio = await _repository.GetByIdAsync(id);
      if (relatorio == null)
        throw new NotFoundException("Relatório de turno não encontrado.");

      await _repository.DeleteAsync(id);
    }
  }
}
