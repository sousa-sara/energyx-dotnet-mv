using EnergyX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Interfaces
{
    public interface IReatorRepository
    {
        Task<Reatores> GetByIdAsync(long id);
        Task<IEnumerable<Reatores>> GetAllAsync();
        Task AddAsync(Reatores reator);
        Task UpdateAsync(Reatores reator);
        Task DeleteAsync(long id);
    }
}
