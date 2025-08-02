using GestaoClinica.ViewModel;

namespace GestaoClinica.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteViewModel>> ListarClienteAsync();
        Task<ClienteViewModel?> ObterClientePorIdAsync(int id);
        Task AdicionarAsync(ClienteViewModel clienteViewModel);
        Task AtualizarAsync(ClienteViewModel clienteViewModel);
        Task ExcluirAsync(int id);
        Task<IEnumerable<ClienteViewModel>> ProcurarClientesAsync(string pesquisa);

    }

}
