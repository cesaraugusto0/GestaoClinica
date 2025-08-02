using GestaoClinica.Entities;

namespace GestaoClinica.Services.Interfaces
{
    public interface IFuncionarioService
    {
        Task AdicionarAsync(Funcionario funcionario);
        Task AtualizarAsync(Funcionario funcionario);
        Task ExcluirAsync(int id);
        Task<IEnumerable<Funcionario>> ListarFuncionarioAsync();
        Task<Funcionario> ObterFuncionarioPorIdAsync(int id);
    }
}
