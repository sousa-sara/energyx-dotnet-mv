using EnergyX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Interfaces
{
    public interface IRelatoriosTurnoRepository
    {
        Task<RelatoriosTurno> GetByIdAsync(long id);
        Task<IEnumerable<RelatoriosTurno>> GetAllAsync();
        Task AddAsync(RelatoriosTurno relatorioTurno);
        Task UpdateAsync(RelatoriosTurno relatorioTurno);
        Task DeleteAsync(long id);
    }
}
