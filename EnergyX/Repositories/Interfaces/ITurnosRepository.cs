using EnergyX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Interfaces
{
    public interface ITurnoRepository
    {
        Task<Turnos> GetByIdAsync(long id);
        Task<IEnumerable<Turnos>> GetAllAsync();
        Task AddAsync(Turnos turno);
        Task UpdateAsync(Turnos turno);
        Task DeleteAsync(long id);
    }
}
