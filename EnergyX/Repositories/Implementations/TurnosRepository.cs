using EnergyX.Data;
using EnergyX.Models;
using EnergyX.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Implementations
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly ApplicationDbContext _context;

        public TurnoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Turnos> GetByIdAsync(long id)
        {
            return await _context.Turnos.FindAsync(id);
        }

        public async Task<IEnumerable<Turnos>> GetAllAsync()
        {
            return await _context.Turnos.ToListAsync();
        }

        public async Task AddAsync(Turnos turno)
        {
            await _context.Turnos.AddAsync(turno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Turnos turno)
        {
            _context.Turnos.Update(turno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var turno = await GetByIdAsync(id);
            if (turno != null)
            {
                _context.Turnos.Remove(turno);
                await _context.SaveChangesAsync();
            }
        }
    }
}
