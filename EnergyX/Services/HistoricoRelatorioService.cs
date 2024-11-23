using EnergyX.DTOs;
using EnergyX.Repositories.Interfaces;
using AutoMapper;
using EnergyX.Models;
using OdontoFast.Exceptions;

namespace EnergyX.Services
{
  public class HistoricoRelatorioService : IHistoricoRelatorioService
  {
    private readonly IHistoricoRelatorioRepository _repository;
    private readonly IMapper _mapper;

    public HistoricoRelatorioService(IHistoricoRelatorioRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<HistoricoRelatorioDto> CreateHistoricoRelatorioAsync(CreateHistoricoRelatorioDto dto)
    {
      var historico = _mapper.Map<HistoricoRelatorio>(dto);
      await _repository.AddAsync(historico);
      return _mapper.Map<HistoricoRelatorioDto>(historico);
    }

    public async Task<HistoricoRelatorioDto> GetHistoricoRelatorioByIdAsync(long id)
    {
      var historico = await _repository.GetByIdAsync(id);
      if (historico == null)
        throw new NotFoundException("Histórico de relatório não encontrado.");

      return _mapper.Map<HistoricoRelatorioDto>(historico);
    }

    public async Task<IEnumerable<HistoricoRelatorioDto>> GetAllHistoricosRelatorioAsync()
    {
      var historicos = await _repository.GetAllAsync();
      return _mapper.Map<IEnumerable<HistoricoRelatorioDto>>(historicos);
    }

    public async Task<HistoricoRelatorioDto> UpdateHistoricoRelatorioAsync(long id, HistoricoRelatorioDto dto)
    {
      var historico = await _repository.GetByIdAsync(id);
      if (historico == null)
        throw new NotFoundException("Histórico de relatório não encontrado.");

      _mapper.Map(dto, historico);
      await _repository.UpdateAsync(historico);
      return _mapper.Map<HistoricoRelatorioDto>(historico);
    }

    public async Task DeleteHistoricoRelatorioAsync(long id)
    {
      var historico = await _repository.GetByIdAsync(id);
      if (historico == null)
        throw new NotFoundException("Histórico de relatório não encontrado.");

      await _repository.DeleteAsync(id);
    }
  }
}
