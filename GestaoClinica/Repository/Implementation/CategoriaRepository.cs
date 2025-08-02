using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Repository.Implementation
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SQLServerDbContext _context;


        public CategoriaRepository(SQLServerDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Categoria categoria)
        {
            await _context.Categoria.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int idCategoria)
        {
            var categoriaExistente = await _context.Categoria.FindAsync(idCategoria);
            if (categoriaExistente != null)
            {
                _context.Categoria.Remove(categoriaExistente);
            }
        }

        async Task<IEnumerable<Categoria>> ICategoriaRepository.ListarCategoriasAsync()
        {
            return await _context.Categoria.ToListAsync();
        }
    }
}