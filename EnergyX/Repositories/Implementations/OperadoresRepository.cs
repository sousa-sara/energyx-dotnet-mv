using EnergyX.Models;
using EnergyX.Repositories.Interfaces;
using EnergyX.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Implementations
{
    public class OperadoresRepository : Repository<Operadores>, IOperadoresRepository
    {
        public OperadoresRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Operadores> GetByLorAsync(string lor)
        {
            return await _context.Operadores.FirstOrDefaultAsync(o => o.Lor == lor);
        }

        public async Task DeleteAsync(string lor)
        {
            var operador = await GetByLorAsync(lor);
            if (operador != null)
            {
                _context.Operadores.Remove(operador);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Operadores>> GetAllAsync()
        {
            return await _context.Operadores.ToListAsync();
        }

        public async Task AddAsync(Operadores operador)
        {
            await _context.Operadores.AddAsync(operador); // Adiciona ao DbSet
            await _context.SaveChangesAsync(); // Persiste no banco de dados
        }
    }
}
