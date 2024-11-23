using EnergyX.Data;
using EnergyX.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Interfaces
{
    public interface IOperadoresRepository
    {
        Task<Operadores> GetByLorAsync(string lor);
        Task DeleteAsync(string lor);
        Task<IEnumerable<Operadores>> GetAllAsync();
        Task AddAsync(Operadores operador);
    }

}
