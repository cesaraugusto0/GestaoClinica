using GestaoClinica.Entities;

namespace GestaoClinica.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ListarCategoriasAsync();
        Task AdicionarAsync(Categoria categoria);
        Task AtualizarAsync(Categoria categoria);
        Task ExcluirAsync(int idCategoria);
        Task<Categoria> ObterCategoriaPorIdAsync(int id);
        Task<Categoria> ObterPorNomeAsync(string nomeCategoria);

    }
}
