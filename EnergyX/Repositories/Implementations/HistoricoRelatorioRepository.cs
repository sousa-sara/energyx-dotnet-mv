using EnergyX.Data;
using EnergyX.Models;
using EnergyX.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Implementations
{
    public class HistoricoRelatorioRepository : IHistoricoRelatorioRepository
    {
        private readonly ApplicationDbContext _context;

        public HistoricoRelatorioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HistoricoRelatorio> GetByIdAsync(long id)
        {
            return await _context.HistoricoRelatorios.FindAsync(id);
        }

        public async Task<IEnumerable<HistoricoRelatorio>> GetAllAsync()
        {
            return await _context.HistoricoRelatorios.ToListAsync();
        }

        public async Task AddAsync(HistoricoRelatorio historicoRelatorio)
        {
            await _context.HistoricoRelatorios.AddAsync(historicoRelatorio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HistoricoRelatorio historicoRelatorio)
        {
            _context.HistoricoRelatorios.Update(historicoRelatorio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var historicoRelatorio = await GetByIdAsync(id);
            if (historicoRelatorio != null)
            {
                _context.HistoricoRelatorios.Remove(historicoRelatorio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
