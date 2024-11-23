using EnergyX.DTOs;
using EnergyX.Repositories.Interfaces;
using AutoMapper;
using EnergyX.Models;
using OdontoFast.Exceptions;

namespace EnergyX.Services
{
  public class ReatoresService : IReatoresService
  {
    private readonly IReatorRepository _repository;
    private readonly IMapper _mapper;

    public ReatoresService(IReatorRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<ReatoresDto> CreateReatorAsync(CreateReatoresDto dto)
    {
      var reator = _mapper.Map<Reatores>(dto);
      await _repository.AddAsync(reator);
      return _mapper.Map<ReatoresDto>(reator);
    }

    public async Task<ReatoresDto> GetReatorByIdAsync(long id)
    {
      var reator = await _repository.GetByIdAsync(id);
      if (reator == null)
        throw new NotFoundException("Reator não encontrado.");

      return _mapper.Map<ReatoresDto>(reator);
    }

    public async Task<IEnumerable<ReatoresDto>> GetAllReatoresAsync()
    {
      var reatores = await _repository.GetAllAsync();
      return _mapper.Map<IEnumerable<ReatoresDto>>(reatores);
    }

    public async Task<ReatoresDto> UpdateReatorAsync(long id, ReatoresDto dto)
    {
      var reator = await _repository.GetByIdAsync(id);
      if (reator == null)
        throw new NotFoundException("Reator não encontrado.");

      _mapper.Map(dto, reator);
      await _repository.UpdateAsync(reator);
      return _mapper.Map<ReatoresDto>(reator);
    }

    public async Task DeleteReatorAsync(long id)
    {
      var reator = await _repository.GetByIdAsync(id);
      if (reator == null)
        throw new NotFoundException("Reator não encontrado.");

      await _repository.DeleteAsync(id);
    }
  }
}
