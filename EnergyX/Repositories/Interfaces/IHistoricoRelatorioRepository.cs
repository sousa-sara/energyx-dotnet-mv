using EnergyX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Interfaces
{
    public interface IHistoricoRelatorioRepository
    {
        Task<HistoricoRelatorio> GetByIdAsync(long id);
        Task<IEnumerable<HistoricoRelatorio>> GetAllAsync();
        Task AddAsync(HistoricoRelatorio historicoRelatorio);
        Task UpdateAsync(HistoricoRelatorio historicoRelatorio);
        Task DeleteAsync(long id);
    }
}
