using GestaoClinica.Entities;

namespace GestaoClinica.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ListarClienteAsync();
        Task<Cliente> ObterClientePorIdAsync(int id);
        Task AdicionarAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task ExcluirAsync(int id);

    }
}
