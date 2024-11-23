using EnergyX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Interfaces
{
    public interface ILocalizacaoReatorRepository
    {
        Task<LocalizacaoReator> GetByIdAsync(long id);
        Task<IEnumerable<LocalizacaoReator>> GetAllAsync();
        Task AddAsync(LocalizacaoReator localizacaoReator);
        Task UpdateAsync(LocalizacaoReator localizacaoReator);
        Task DeleteAsync(long id);
    }
}
