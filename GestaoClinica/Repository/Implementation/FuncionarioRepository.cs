using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Repository.Interfaces
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly SQLServerDbContext _context;

        public FuncionarioRepository(SQLServerDbContext context)
        {
            _context = context;
        }
        public async Task AdicionarAsync(Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task<Funcionario> ObterFuncionarioPorIdAsync(int id)
        {
            return await _context.Funcionarios
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.IdFuncionario == id);;
        }
        public async Task AtualizarAsync(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var funcionarioExistente = await _context.Funcionarios.FindAsync(id);
            if (funcionarioExistente != null)
            {
                _context.Funcionarios.Remove(funcionarioExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> ListarFuncionarioAsync()
        {
            return await _context.Funcionarios
                .Include(f => f.Endereco)
                .ToListAsync();
        }

    }
}