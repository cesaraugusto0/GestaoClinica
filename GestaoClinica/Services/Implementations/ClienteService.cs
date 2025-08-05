using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;
using GestaoClinica.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient; // ou System.Data.SqlClient


namespace GestaoClinica.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        
        public async Task AdicionarAsync(ClienteViewModel clienteViewModel)
        {
            var cliente = ToEntity(clienteViewModel);
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ArgumentException("O nome é obrigatório!");
            }

            cliente.DataCriacao = DateTime.Now;
            cliente.UltimaAtualizacao = DateTime.Now;
            cliente.Ativo = true;

            try
            {
                await _clienteRepository.AdicionarAsync(cliente);
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
            {
                // Trata erro de truncamento (string too long)
                if (sqlEx.Number == 8152 || sqlEx.Message.Contains("truncat", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        "Um ou mais campos excederam o tamanho máximo permitido. " +
                        "Verifique: CPF (11-14), Telefone (10-11), UF (2), CEP (8-9), etc."
                    );
                }

                // Trata chave duplicada
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                {
                    throw new InvalidOperationException("CPF ou outro dado único já está em uso.");
                }

                // Outros erros do SQL Server
                throw new InvalidOperationException($"Erro no banco de dados: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Qualquer outro erro
                throw new Exception("Ocorreu um erro inesperado ao salvar o cliente.", ex);
            }
        }




        public async Task AtualizarAsync(ClienteViewModel clienteViewModel)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(clienteViewModel.IdCliente);
            
            if (cliente != null)
            {
                // Atualiza as propriedades de Pessoa
                cliente.Nome = clienteViewModel.Nome;
                cliente.CPF = clienteViewModel.CPF;
                cliente.DataNascimento = clienteViewModel.DataNascimento;
                cliente.Telefone = clienteViewModel.Telefone;
                cliente.Email = clienteViewModel.Email;

                // Atualiza as propriedades de Cliente
                cliente.Observacoes = clienteViewModel.Observacoes;
                cliente.Ativo = clienteViewModel.Ativo;
                cliente.EnderecoId = clienteViewModel.EnderecoId;

                // Atualiza endereço se existir
                if (cliente.Endereco != null && clienteViewModel.Endereco != null)
                {
                    cliente.Endereco.Logradouro = clienteViewModel.Endereco.Logradouro;
                    cliente.Endereco.Numero = clienteViewModel.Endereco.Numero;
                    cliente.Endereco.Complemento = clienteViewModel.Endereco.Complemento;
                    cliente.Endereco.Cidade = clienteViewModel.Endereco.Cidade;
                    cliente.Endereco.Uf = clienteViewModel.Endereco.Uf;
                    cliente.Endereco.Cep = clienteViewModel.Endereco.Cep;
                }

                cliente.UltimaAtualizacao = DateTime.UtcNow;

                await _clienteRepository.AtualizarAsync(cliente);
            }
        }
        
        public async Task ExcluirAsync(int id)
        {
            await _clienteRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<ClienteViewModel>> ListarClienteAsync()
        {
            var clientes = await _clienteRepository.ListarClienteAsync();
            return clientes.Select(ToViewModel);
        }

        public async Task<ClienteViewModel?> ObterClientePorIdAsync(int id)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
            }
            return ToViewModel(cliente);
        }

        public async Task<IEnumerable<ClienteViewModel>> ProcurarClientesAsync(string pesquisa)
        {
            var clientes = await _clienteRepository.ListarClienteAsync();

            if (string.IsNullOrWhiteSpace(pesquisa))
                return clientes.Select(ToViewModel);

            pesquisa = pesquisa.ToLower();
            var pesquisaFiltrada = clientes.Where(c =>
                c.Nome.ToLower().Contains(pesquisa) ||
                c.CPF.Contains(pesquisa) ||
                (c.Email?.ToLower().Contains(pesquisa) ?? false) ||
                (c.Telefone?.Contains(pesquisa) ?? false)
            );

            return pesquisaFiltrada.Select(ToViewModel);
        }

        // Métodos de mapeamento
        private ClienteViewModel ToViewModel(Cliente cliente)
        {
            return new ClienteViewModel
            {
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                DataNascimento = cliente.DataNascimento,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                Observacoes = cliente.Observacoes,
                Ativo = cliente.Ativo,
                EnderecoId = cliente.EnderecoId,
                Endereco = cliente.Endereco != null ? new EnderecoViewModel
                {
                    Logradouro = cliente.Endereco.Logradouro,
                    Numero = cliente.Endereco.Numero,
                    Complemento = cliente.Endereco.Complemento,
                    Cidade = cliente.Endereco.Cidade,
                    Uf = cliente.Endereco.Uf,
                    Cep = cliente.Endereco.Cep
                } : null
            };
        }

        private Cliente ToEntity(ClienteViewModel clienteViewModel)
        {
            var cliente = new Cliente
            {
                IdCliente = clienteViewModel.IdCliente,
                Nome = clienteViewModel.Nome,
                CPF = clienteViewModel.CPF,
                DataNascimento = clienteViewModel.DataNascimento,
                Telefone = clienteViewModel.Telefone,
                Email = clienteViewModel.Email,
                Observacoes = clienteViewModel.Observacoes,
                Ativo = clienteViewModel.Ativo,
                EnderecoId = clienteViewModel.EnderecoId
            };

            // Se houver endereço no ViewModel, cria o objeto Endereco
            if (clienteViewModel.Endereco != null)
            {
                cliente.Endereco = new Endereco
                {
                    Logradouro = clienteViewModel.Endereco.Logradouro,
                    Numero = clienteViewModel.Endereco.Numero,
                    Complemento = clienteViewModel.Endereco.Complemento,
                    Cidade = clienteViewModel.Endereco.Cidade,
                    Uf = clienteViewModel.Endereco.Uf,
                    Cep = clienteViewModel.Endereco.Cep
                };
            }

            return cliente;
        }

    }
}
