using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;

namespace GestaoClinica.Services.Implementations
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task AdicionarAsync(Funcionario funcionario)
        {
            if (string.IsNullOrEmpty(funcionario.Nome))
            {
                throw new ArgumentException("O nome é obrigatório!");
            }

            // funcionario.IdFuncionario = GerarId();
            funcionario.DataCriacao = DateTime.Now;
            funcionario.UltimaAtualizacao = DateTime.Now;
            funcionario.Ativo = true;

            // Não force IdFuncionario → o banco gera
            await _funcionarioRepository.AdicionarAsync(funcionario);
        }

        public async Task AtualizarAsync(Funcionario funcionario)
        {
            await _funcionarioRepository.AtualizarAsync(funcionario);
            funcionario.UltimaAtualizacao = DateTime.Now;
        }

        public async Task ExcluirAsync(int id)
        {
            await _funcionarioRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<Funcionario>> ListarFuncionarioAsync()
        {
            return await _funcionarioRepository.ListarFuncionarioAsync();
        }

        public Task<Funcionario> ObterFuncionarioPorIdAsync(int id)
        {
            var funcionario = _funcionarioRepository.ObterFuncionarioPorIdAsync(id);
            if (funcionario == null)
            {
                throw new KeyNotFoundException($"Funcionario com {id} não encontrado.");
            }
            return funcionario;
        }
    }
}
