using EnergyX.DTOs;
using EnergyX.Models;
using EnergyX.Repositories.Interfaces;
using AutoMapper;
using OdontoFast.Exceptions;

public class TipoReatorService : ITipoReatorService
{
  private readonly ITipoReatorRepository _tipoReatorRepository;
  private readonly IMapper _mapper;

  public TipoReatorService(ITipoReatorRepository tipoReatorRepository, IMapper mapper)
  {
    _tipoReatorRepository = tipoReatorRepository;
    _mapper = mapper;
  }

  public async Task<TipoReatorDto> CreateTipoReatorAsync(CreateTipoReatorDto dto)
  {
    var tipoReator = _mapper.Map<TipoReator>(dto);
    await _tipoReatorRepository.AddAsync(tipoReator);
    return _mapper.Map<TipoReatorDto>(tipoReator);
  }

  public async Task<TipoReatorDto> GetTipoReatorByIdAsync(long id)
  {
    var tipoReator = await _tipoReatorRepository.GetByIdAsync(id);
    if (tipoReator == null)
      throw new NotFoundException("Tipo de reator não encontrado.");
    return _mapper.Map<TipoReatorDto>(tipoReator);
  }

  public async Task<IEnumerable<TipoReatorDto>> GetAllTipoReatoresAsync(int pageNumber, int pageSize)
  {
    var tipoReatores = await _tipoReatorRepository.GetAllAsync();
    return tipoReatores.Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .Select(t => _mapper.Map<TipoReatorDto>(t));
  }

  public async Task<TipoReatorDto> UpdateTipoReatorAsync(long id, TipoReatorDto dto)
  {
    var tipoReator = await _tipoReatorRepository.GetByIdAsync(id);
    if (tipoReator == null)
      throw new NotFoundException("Tipo de reator não encontrado.");
    _mapper.Map(dto, tipoReator);
    await _tipoReatorRepository.UpdateAsync(tipoReator);
    return _mapper.Map<TipoReatorDto>(tipoReator);
  }

  public async Task DeleteTipoReatorAsync(long id)
  {
    var tipoReator = await _tipoReatorRepository.GetByIdAsync(id);
    if (tipoReator == null)
      throw new NotFoundException("Tipo de reator não encontrado.");
    await _tipoReatorRepository.DeleteAsync(id);
  }
}
