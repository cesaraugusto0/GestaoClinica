using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private static readonly Random _random = new Random();


        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ArgumentException("O nome é obrigatório!");
            }

            cliente.IdCliente = GerarId();
            cliente.DataCriacao = DateTime.Now;
            cliente.UltimaAtualizacao = DateTime.Now;
            cliente.Ativo = true;

            // Não force IdCliente → o banco gera
            await _clienteRepository.AdicionarAsync(cliente);
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            await _clienteRepository.AtualizarAsync(cliente);
            cliente.UltimaAtualizacao = DateTime.Now;
        }

        public async Task ExcluirAsync(int id)
        {
            await _clienteRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<Cliente>> ListarClienteAsync()
        {
            return await _clienteRepository.ListarClienteAsync();
        }

        public Task<Cliente> ObterClientePorIdAsync(int id)
        {
            var cliente = _clienteRepository.ObterClientePorIdAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException($"Cliente com {id} não encontrado.");
            }
            return cliente;
        }


        private int GerarId()
        {
            lock (_random) // Evita problemas em execução multi-thread
            {
                return _random.Next(10000000, 100000000); // Gera número entre 10.000.000 e 99.999.999
            }
        }
    }
}
