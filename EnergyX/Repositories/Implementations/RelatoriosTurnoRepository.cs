using EnergyX.Data;
using EnergyX.Models;
using EnergyX.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyX.Repositories.Implementations
{

    public class RelatoriosTurnoRepository : Repository<RelatoriosTurno>, IRelatoriosTurnoRepository
    {

        public RelatoriosTurnoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<RelatoriosTurno> GetByIdAsync(long id)
        {
            return await _context.RelatoriosTurnos.FindAsync(id);
        }

        public async Task<IEnumerable<RelatoriosTurno>> GetAllAsync()
        {
            return await _context.RelatoriosTurnos.ToListAsync();

            // var relatorios = await _context.RelatoriosTurnos.ToListAsync();
            // // Log para verificar os dados
            // Console.WriteLine($"Total de relatórios encontrados: {relatorios.Count}");
            // return relatorios;
        }

        public async Task AddAsync(RelatoriosTurno relatorioTurno)
        {
            try
            {
                Console.WriteLine("Iniciando inserção no banco de dados...");
                await _context.RelatoriosTurnos.AddAsync(relatorioTurno);
                await _context.SaveChangesAsync();
                Console.WriteLine("Relatório salvo no banco com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir no banco: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(RelatoriosTurno relatorioTurno)
        {
            _context.RelatoriosTurnos.Update(relatorioTurno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var relatorioTurno = await GetByIdAsync(id);
            if (relatorioTurno != null)
            {
                _context.RelatoriosTurnos.Remove(relatorioTurno);
                await _context.SaveChangesAsync();
            }
        }
    }
}
