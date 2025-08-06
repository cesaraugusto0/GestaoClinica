using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using GestaoClinica.Entities.GestaoClinica.Entities;

namespace GestaoClinica.Repository.Implementation
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly SQLServerDbContext _context;

        public ServicoRepository(SQLServerDbContext context)
        {
            _context = context;
        }
        public async Task AdicionarAsync(Servico servico)
        {
            await _context.Servicos.AddAsync(servico);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Servico servico)
        {
            _context.Servicos.Update(servico);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var clienteExistente = await _context.Servicos.FindAsync(id);
            if (clienteExistente != null)
            {
                _context.Servicos.Remove(clienteExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Servico>> ListarServicoAsync()
        {
            return await _context.Servicos
                .Include(c => c.Categoria)
                .ToListAsync();
        }

        public async Task<Servico> ObterServicoPorIdAsync(int id)
        {
            return await _context.Servicos
.Include(c => c.Categoria)
.FirstOrDefaultAsync(c => c.IdServico == id);
        }
    }
}
