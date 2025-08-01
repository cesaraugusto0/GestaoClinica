using GestaoClinica.Entities;

namespace GestaoClinica.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ListarClienteAsync();
        Task<Cliente> ObterClientePorIdAsync(int id);
        Task AdicionarAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task ExcluirAsync(int id);
    }
}