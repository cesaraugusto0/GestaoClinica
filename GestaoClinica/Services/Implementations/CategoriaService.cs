
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

    // 🔍 Verifica se já existe uma categoria com o mesmo nome (case-insensitive)
    var nomeExistente = await _categoriaRepository.ObterPorNomeAsync(categoria.NomeCategoria.Trim());
    if (nomeExistente != null)
    {
        throw new InvalidOperationException($"Já existe uma categoria com o nome '{categoria.NomeCategoria}'.");
    }

    categoria.DataCriacao = DateTime.UtcNow;
    categoria.UltimaAtualizacao = DateTime.UtcNow;

    await _categoriaRepository.AdicionarAsync(categoria);
}

        public async Task AtualizarAsync(Categoria categoria)
        {
            categoria.UltimaAtualizacao = DateTime.Now;
            await _categoriaRepository.AtualizarAsync(categoria);
        }

public async Task ExcluirAsync(int idCategoria)
{
    var categoria = await _categoriaRepository.ObterCategoriaPorIdAsync(idCategoria);
    if (categoria == null)
    {
        throw new KeyNotFoundException($"Categoria com ID {idCategoria} não encontrada.");
    }

    await _categoriaRepository.ExcluirAsync(idCategoria);
}

        public async Task<Categoria> ObterCategoriaPorIdAsync(int id)
        {
            var categoria = await _categoriaRepository.ObterCategoriaPorIdAsync(id);

            if (categoria == null)
            {
                throw new KeyNotFoundException($"A categoria com id {id} não foi localizado");
            }
            return categoria;
        }

        async Task<IEnumerable<Categoria>> ICategoriaService.ListarCategoriasAsync()
        {
            return await _categoriaRepository.ListarCategoriasAsync();
        }
    }
}