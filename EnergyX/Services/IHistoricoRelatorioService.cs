using EnergyX.DTOs;

namespace EnergyX.Services
{
  public interface IHistoricoRelatorioService
  {
    Task<HistoricoRelatorioDto> CreateHistoricoRelatorioAsync(CreateHistoricoRelatorioDto dto);
    Task<HistoricoRelatorioDto> GetHistoricoRelatorioByIdAsync(long id);
    Task<IEnumerable<HistoricoRelatorioDto>> GetAllHistoricosRelatorioAsync();
    Task<HistoricoRelatorioDto> UpdateHistoricoRelatorioAsync(long id, HistoricoRelatorioDto dto);
    Task DeleteHistoricoRelatorioAsync(long id);
  }
}
