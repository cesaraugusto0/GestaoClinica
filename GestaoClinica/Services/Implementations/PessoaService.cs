using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using GestaoClinica.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Services.Implementations
{
    public class PessoaService : IPessoaService
    {
        private readonly SQLServerDbContext _context;

        public PessoaService(SQLServerDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Pessoa>> ListarPessoasAsync()
        {
            return await _context.pessoas.ToListAsync();
        }
    }
}
