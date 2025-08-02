using GestaoClinica.DTO;
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoClinica.Data.Services.Implementations
{
    public class ClienteDTOService : IClienteDTOService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDTOService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllClientesAsync()
        {
            var clientes = await _clienteRepository.ListarClienteAsync();
            return clientes.Select(ToDTO);
        }

        public async Task<ClienteDTO?> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(id);
            return cliente != null ? ToDTO(cliente) : null;
        }

        public async Task<int> CreateClienteAsync(ClienteDTO clienteDto)
        {
            var cliente = ToEntity(clienteDto);
            await _clienteRepository.AdicionarAsync(cliente);
            return cliente.IdCliente;
        }

        public async Task UpdateClienteAsync(ClienteDTO clienteDto)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(clienteDto.IdCliente);
            if (cliente != null)
            {
                // Atualiza as propriedades de Pessoa
                cliente.Nome = clienteDto.Nome;
                cliente.CPF = clienteDto.CPF;
                cliente.DataNascimento = clienteDto.DataNascimento;
                cliente.Telefone = clienteDto.Telefone;
                cliente.Email = clienteDto.Email;

                // Atualiza as propriedades de Cliente
                cliente.Observacoes = clienteDto.Observacoes;
                cliente.Ativo = clienteDto.Ativo;
                cliente.EnderecoId = clienteDto.EnderecoId;

                // Atualiza endereço se existir
                if (cliente.Endereco != null && clienteDto.Endereco != null)
                {
                    cliente.Endereco.Logradouro = clienteDto.Endereco.Logradouro;
                    cliente.Endereco.Numero = clienteDto.Endereco.Numero;
                    cliente.Endereco.Complemento = clienteDto.Endereco.Complemento;
                    cliente.Endereco.Cidade = clienteDto.Endereco.Cidade;
                    cliente.Endereco.Uf = clienteDto.Endereco.Uf;
                    cliente.Endereco.Cep = clienteDto.Endereco.Cep;
                }

                await _clienteRepository.AtualizarAsync(cliente);
            }
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<ClienteDTO>> SearchClientesAsync(string searchTerm)
        {
            var clientes = await _clienteRepository.ListarClienteAsync();

            if (string.IsNullOrWhiteSpace(searchTerm))
                return clientes.Select(ToDTO);

            searchTerm = searchTerm.ToLower();
            var filtered = clientes.Where(c =>
                c.Nome.ToLower().Contains(searchTerm) ||
                c.CPF.Contains(searchTerm) ||
                (c.Email?.ToLower().Contains(searchTerm) ?? false) ||
                (c.Telefone?.Contains(searchTerm) ?? false)
            );

            return filtered.Select(ToDTO);
        }

        // Métodos de mapeamento
        private ClienteDTO ToDTO(Cliente cliente)
        {
            return new ClienteDTO
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
                Endereco = cliente.Endereco != null ? new EnderecoDTO
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

        private Cliente ToEntity(ClienteDTO clienteDto)
        {
            var cliente = new Cliente
            {
                IdCliente = clienteDto.IdCliente,
                Nome = clienteDto.Nome,
                CPF = clienteDto.CPF,
                DataNascimento = clienteDto.DataNascimento,
                Telefone = clienteDto.Telefone,
                Email = clienteDto.Email,
                Observacoes = clienteDto.Observacoes,
                Ativo = clienteDto.Ativo,
                EnderecoId = clienteDto.EnderecoId
            };

            // Se houver endereço no DTO, cria o objeto Endereco
            if (clienteDto.Endereco != null)
            {
                cliente.Endereco = new Endereco
                {
                    Logradouro = clienteDto.Endereco.Logradouro,
                    Numero = clienteDto.Endereco.Numero,
                    Complemento = clienteDto.Endereco.Complemento,
                    Cidade = clienteDto.Endereco.Cidade,
                    Uf = clienteDto.Endereco.Uf,
                    Cep = clienteDto.Endereco.Cep
                };
            }

            return cliente;
        }
    }
}