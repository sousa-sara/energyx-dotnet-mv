using EnergyX.Data;
using EnergyX.Models;
using EnergyX.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Implementations
{
    public class ReatorRepository : IReatorRepository
    {
        private readonly ApplicationDbContext _context;

        public ReatorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reatores> GetByIdAsync(long id)
        {
            return await _context.Reatores.FindAsync(id);
        }

        public async Task<IEnumerable<Reatores>> GetAllAsync()
        {
            return await _context.Reatores.ToListAsync();
        }

        public async Task AddAsync(Reatores reator)
        {
            await _context.Reatores.AddAsync(reator);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reatores reator)
        {
            _context.Reatores.Update(reator);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var reator = await GetByIdAsync(id);
            if (reator != null)
            {
                _context.Reatores.Remove(reator);
                await _context.SaveChangesAsync();
            }
        }
    }
}
