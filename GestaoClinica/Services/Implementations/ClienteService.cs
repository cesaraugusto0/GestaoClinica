using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using GestaoClinica.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly SQLServerDbContext _context;

        public ClienteService(SQLServerDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Cliente>> ListarClientesAsync()
        {
            return await _context.clientes.ToListAsync();
        }
    }
}
