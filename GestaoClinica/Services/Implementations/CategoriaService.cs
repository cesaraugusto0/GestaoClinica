
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;

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
            await _categoriaRepository.ExcluirAsync(idCategoria);
        }

        async Task<IEnumerable<Categoria>> ICategoriaService.ListarCategoriasAsync()
        {
            return await _categoriaRepository.ListarCategoriasAsync();
        }
    }
}