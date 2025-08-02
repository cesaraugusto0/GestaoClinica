
using GestaoClinica.Entities;
using GestaoClinica.Repository.Implementation;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task AdicionarAsync(Categoria categoria)
        {
            if (string.IsNullOrEmpty(categoria.NomeCategoria))
            {
                throw new ArgumentException("É obrigatório definir um nome para a categoria");
            }
            categoria.DataCriacao = DateTime.Now;
            categoria.UltimaAtualizacao = DateTime.Now;
            await _categoriaRepository.AdicionarAsync(categoria);
        }

        public async Task AtualizarAsync(Categoria categoria)
        {
            await _categoriaRepository.AtualizarAsync(categoria);
            categoria.UltimaAtualizacao = DateTime.Now;
        }

       public async Task ExcluirAsync(int idCategoria)
        {
            var categoria = _categoriaRepository.ObterCategoriaPorIdAsync(idCategoria);
            await _categoriaRepository.ExcluirAsync(idCategoria);
        }

        public async Task<Categoria> ObterCategoriaPorIdAsync(int id)
        {
            var categoria = await _categoriaRepository.ObterCategoriaPorIdAsync(id);

            if (categoria == null)
            {
                throw new KeyNotFoundException($"O categoria com id {id} não foi localizado");
            }
            return categoria;
        }

        async Task<IEnumerable<Categoria>> ICategoriaService.ListarCategoriasAsync()
        {
            return await _categoriaRepository.ListarCategoriasAsync();
        }
    }
}