using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public Task AtualizarAsync(Servico servico)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Servico servico)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Servico>> ListarServicoAsync()
        {
            return await _context.Servicos.ToListAsync();
        }
    }
}
