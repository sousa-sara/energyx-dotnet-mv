using EnergyX.DTOs;

public interface ITipoReatorService
{
  Task<TipoReatorDto> CreateTipoReatorAsync(CreateTipoReatorDto dto);
  Task<TipoReatorDto> GetTipoReatorByIdAsync(long id);
  Task<IEnumerable<TipoReatorDto>> GetAllTipoReatoresAsync(int pageNumber, int pageSize);
  Task<TipoReatorDto> UpdateTipoReatorAsync(long id, TipoReatorDto dto);
  Task DeleteTipoReatorAsync(long id);
}
