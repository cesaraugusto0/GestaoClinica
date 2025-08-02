using GestaoClinica.Entities;

namespace GestaoClinica.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> ListarFuncionarioAsync();
        Task<Funcionario> ObterFuncionarioPorIdAsync(int id);
        Task AdicionarAsync(Funcionario funcionario);
        Task AtualizarAsync(Funcionario funcionario);
        Task ExcluirAsync(int id);
    }
}