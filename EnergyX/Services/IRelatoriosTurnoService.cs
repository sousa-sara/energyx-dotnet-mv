using EnergyX.DTOs;

namespace EnergyX.Services
{
  public interface IRelatoriosTurnoService
  {
    Task<RelatoriosTurnoDto> CreateRelatorioTurnoAsync(CreateRelatoriosTurnoDto dto);
    Task<RelatoriosTurnoDto> GetRelatorioTurnoByIdAsync(long id);
    Task<IEnumerable<RelatoriosTurnoDto>> GetAllRelatoriosTurnoAsync(int pageNumber, int pageSize);
    Task<RelatoriosTurnoDto> UpdateRelatorioTurnoAsync(long id, UpdateRelatoriosTurnoDto dto);
    Task DeleteRelatorioTurnoAsync(long id);
  }
}
