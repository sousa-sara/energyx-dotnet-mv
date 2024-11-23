using EnergyX.DTOs;

namespace EnergyX.Services
{
  public interface IReatoresService
  {
    Task<ReatoresDto> CreateReatorAsync(CreateReatoresDto dto);
    Task<ReatoresDto> GetReatorByIdAsync(long id);
    Task<IEnumerable<ReatoresDto>> GetAllReatoresAsync();
    Task<ReatoresDto> UpdateReatorAsync(long id, ReatoresDto dto);
    Task DeleteReatorAsync(long id);
  }
}
