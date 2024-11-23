using EnergyX.DTOs;

namespace EnergyX.Services
{
    public interface ITurnosService
    {
        Task<TurnosDto> CreateTurnoAsync(CreateTurnosDto dto);
        Task<TurnosDto> GetTurnoByIdAsync(long id);
        Task<IEnumerable<TurnosDto>> GetAllTurnosAsync(int pageNumber, int pageSize);
        Task<TurnosDto> UpdateTurnoAsync(long id, TurnosDto dto);
        Task DeleteTurnoAsync(long id);
    }
}
