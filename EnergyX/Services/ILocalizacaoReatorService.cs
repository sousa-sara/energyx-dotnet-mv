using EnergyX.DTOs;

namespace EnergyX.Services
{
  public interface ILocalizacaoReatorService
  {
    Task<LocalizacaoReatorDto> CreateLocalizacaoReatorAsync(CreateLocalizacaoReatorDto dto);
    Task<LocalizacaoReatorDto> GetLocalizacaoReatorByIdAsync(long id);
    Task<IEnumerable<LocalizacaoReatorDto>> GetAllLocalizacoesReatorAsync();
    Task<LocalizacaoReatorDto> UpdateLocalizacaoReatorAsync(long id, LocalizacaoReatorDto dto);
    Task DeleteLocalizacaoReatorAsync(long id);
  }
}
