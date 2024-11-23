using EnergyX.DTOs;
using EnergyX.Repositories.Interfaces;
using AutoMapper;
using EnergyX.Models;
using OdontoFast.Exceptions;

namespace EnergyX.Services
{
  public class LocalizacaoReatorService : ILocalizacaoReatorService
  {
    private readonly ILocalizacaoReatorRepository _repository;
    private readonly IMapper _mapper;

    public LocalizacaoReatorService(ILocalizacaoReatorRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<LocalizacaoReatorDto> CreateLocalizacaoReatorAsync(CreateLocalizacaoReatorDto dto)
    {
      var localizacao = _mapper.Map<LocalizacaoReator>(dto);
      await _repository.AddAsync(localizacao);
      return _mapper.Map<LocalizacaoReatorDto>(localizacao);
    }

    public async Task<LocalizacaoReatorDto> GetLocalizacaoReatorByIdAsync(long id)
    {
      var localizacao = await _repository.GetByIdAsync(id);
      if (localizacao == null)
        throw new NotFoundException("Localização do reator não encontrada.");

      return _mapper.Map<LocalizacaoReatorDto>(localizacao);
    }

    public async Task<IEnumerable<LocalizacaoReatorDto>> GetAllLocalizacoesReatorAsync()
    {
      var localizacoes = await _repository.GetAllAsync();
      return _mapper.Map<IEnumerable<LocalizacaoReatorDto>>(localizacoes);
    }

    public async Task<LocalizacaoReatorDto> UpdateLocalizacaoReatorAsync(long id, LocalizacaoReatorDto dto)
    {
      var localizacao = await _repository.GetByIdAsync(id);
      if (localizacao == null)
        throw new NotFoundException("Localização do reator não encontrada.");

      _mapper.Map(dto, localizacao);
      await _repository.UpdateAsync(localizacao);
      return _mapper.Map<LocalizacaoReatorDto>(localizacao);
    }

    public async Task DeleteLocalizacaoReatorAsync(long id)
    {
      var localizacao = await _repository.GetByIdAsync(id);
      if (localizacao == null)
        throw new NotFoundException("Localização do reator não encontrada.");

      await _repository.DeleteAsync(id);
    }
  }
}
