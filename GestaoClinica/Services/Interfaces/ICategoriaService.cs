using GestaoClinica.Entities;

namespace GestaoClinica.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ListarCategoriasAsync();
        Task<Categoria> ObterCategoriaPorIdAsync(int id);

        Task AdicionarAsync(Categoria categoria);
        Task AtualizarAsync(Categoria categoria);
        Task ExcluirAsync(int idCategoria);
    }
}
