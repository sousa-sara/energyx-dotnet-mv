using EnergyX.Data;
using EnergyX.Models;
using EnergyX.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace EnergyX.Repositories.Implementations
{
    public class TipoReatorRepository : ITipoReatorRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoReatorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TipoReator> GetByIdAsync(long id)
        {
            return await _context.TiposReatores.FindAsync(id); 
        }

        public async Task<IEnumerable<TipoReator>> GetAllAsync()
        {
            return await _context.TiposReatores.ToListAsync();
        }

        public async Task AddAsync(TipoReator tipoReator)
        {
            await _context.TiposReatores.AddAsync(tipoReator);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoReator tipoReator)
        {
            _context.TiposReatores.Update(tipoReator);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var tipoReator = await GetByIdAsync(id);
            if (tipoReator != null)
            {
                _context.TiposReatores.Remove(tipoReator);
                await _context.SaveChangesAsync();
            }
        }
    }
}
