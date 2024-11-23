using EnergyX.Data;
using EnergyX.Models;
using EnergyX.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Implementations
{
    public class LocalizacaoReatorRepository : ILocalizacaoReatorRepository
    {
        private readonly ApplicationDbContext _context;

        public LocalizacaoReatorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LocalizacaoReator> GetByIdAsync(long id)
        {
            return await _context.LocalizacoesReatores.FindAsync(id);
        }

        public async Task<IEnumerable<LocalizacaoReator>> GetAllAsync()
        {
            return await _context.LocalizacoesReatores.ToListAsync();
        }

        public async Task AddAsync(LocalizacaoReator localizacaoReator)
        {
            await _context.LocalizacoesReatores.AddAsync(localizacaoReator);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LocalizacaoReator localizacaoReator)
        {
            _context.LocalizacoesReatores.Update(localizacaoReator);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var localizacaoReator = await GetByIdAsync(id);
            if (localizacaoReator != null)
            {
                _context.LocalizacoesReatores.Remove(localizacaoReator);
                await _context.SaveChangesAsync();
            }
        }
    }
}
