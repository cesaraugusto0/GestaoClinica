using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Repository.Interfaces
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SQLServerDbContext _context;

        public ClienteRepository(SQLServerDbContext context)
        {
            _context = context;
        }
        public async Task AdicionarAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }


        public async Task AtualizarAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);
            if (clienteExistente != null)
            {
                _context.Clientes.Remove(clienteExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cliente>> ListarClienteAsync()
        {
            return await _context.Clientes
        .Include(c => c.Endereco)
        .ToListAsync();
        }

        public async Task<Cliente> ObterClientePorIdAsync(int id)
        {
            return await _context.Clientes
        .Include(c => c.Endereco)
        .FirstOrDefaultAsync(c => c.IdCliente == id);
        }
    }
}