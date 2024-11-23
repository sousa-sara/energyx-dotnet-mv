using EnergyX.DTOs;

namespace EnergyX.Services
{
    public interface IOperadoresService
    {
        Task<OperadoresDto> GetOperadorByLorAsync(string lor);
        Task<OperadoresDto> LoginAsync(OperadorLoginDto loginDto);
        Task<IEnumerable<OperadoresDto>> GetAllOperadoresAsync(int pageNumber, int pageSize);
        Task<OperadoresDto> CreateOperadoresAsync(CreateOperadoresDto dto);
    }
}
