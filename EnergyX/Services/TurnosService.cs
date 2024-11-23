using EnergyX.DTOs;
using EnergyX.Models;
using EnergyX.Repositories.Interfaces;
using AutoMapper;
using OdontoFast.Exceptions;

namespace EnergyX.Services
{
  public class TurnosService : ITurnosService
  {
    private readonly ITurnoRepository _turnosRepository;
    private readonly IMapper _mapper;

    public TurnosService(ITurnoRepository turnosRepository, IMapper mapper)
    {
      _turnosRepository = turnosRepository;
      _mapper = mapper;
    }

    public async Task<TurnosDto> CreateTurnoAsync(CreateTurnosDto dto)
    {
      var turno = _mapper.Map<Turnos>(dto);
      await _turnosRepository.AddAsync(turno);
      return _mapper.Map<TurnosDto>(turno);
    }

    public async Task<TurnosDto> GetTurnoByIdAsync(long id)
    {
      var turno = await _turnosRepository.GetByIdAsync(id);
      if (turno == null)
        throw new NotFoundException("Turno não encontrado.");
      return _mapper.Map<TurnosDto>(turno);
    }

    public async Task<IEnumerable<TurnosDto>> GetAllTurnosAsync(int pageNumber, int pageSize)
    {
      var turnos = await _turnosRepository.GetAllAsync();
      return turnos.Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .Select(t => _mapper.Map<TurnosDto>(t));
    }

    public async Task<TurnosDto> UpdateTurnoAsync(long id, TurnosDto dto)
    {
      var turno = await _turnosRepository.GetByIdAsync(id);
      if (turno == null)
        throw new NotFoundException("Turno não encontrado.");

      _mapper.Map(dto, turno);
      await _turnosRepository.UpdateAsync(turno);
      return _mapper.Map<TurnosDto>(turno);
    }

    public async Task DeleteTurnoAsync(long id)
    {
      var turno = await _turnosRepository.GetByIdAsync(id);
      if (turno == null)
        throw new NotFoundException("Turno não encontrado.");
      await _turnosRepository.DeleteAsync(id);
    }
  }
}
