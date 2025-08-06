using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
        // Services/Implementations/ClienteService.cs
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


public async Task AdicionarAsync(Cliente cliente)
{
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

        public async Task<Cliente> ObterClientePorIdAsync(int id)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
            }
            return cliente;
        }

    }
}
