using EnergyX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Interfaces
{
    public interface ITipoReatorRepository
    {
        Task<TipoReator> GetByIdAsync(long id);
        Task<IEnumerable<TipoReator>> GetAllAsync();
        Task AddAsync(TipoReator tipoReator);
        Task UpdateAsync(TipoReator tipoReator);
        Task DeleteAsync(long id);
    }
}
