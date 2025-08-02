using GestaoClinica.DTO;
using GestaoClinica.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoClinica.Data.Services.Implementations
{
    public class MockClienteDTOService : IClienteDTOService
    {
        private readonly List<ClienteDTO> _clientes = new List<ClienteDTO>
        {
            new ClienteDTO
            {
                IdCliente = 1,
                Nome = "João Silva",
                CPF = "123.456.789-00",
                DataNascimento = new DateTime(1985, 5, 15),
                Telefone = "(11) 99999-9999",
                Email = "joao@email.com",
                Observacoes = "Paciente regular",
                Ativo = true,
                Endereco = new EnderecoDTO
                {
                    Logradouro = "Rua das Flores",
                    Numero = "123",
                    Cidade = "São Paulo",
                    Uf = "SP",
                    Cep = "01001-000"
                }
            }
        };

        public async Task<IEnumerable<ClienteDTO>> GetAllClientesAsync()
        {
            await Task.Delay(100);
            return _clientes;
        }

        public async Task<ClienteDTO?> GetClienteByIdAsync(int id)
        {
            await Task.Delay(50);
            return _clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public async Task<int> CreateClienteAsync(ClienteDTO cliente)
        {
            await Task.Delay(200);
            cliente.IdCliente = _clientes.Max(c => c.IdCliente) + 1;
            _clientes.Add(cliente);
            return cliente.IdCliente;
        }

        public async Task UpdateClienteAsync(ClienteDTO cliente)
        {
            await Task.Delay(200);
            var existing = _clientes.FirstOrDefault(c => c.IdCliente == cliente.IdCliente);
            if (existing != null)
            {
                var index = _clientes.IndexOf(existing);
                _clientes[index] = cliente;
            }
        }

        public async Task DeleteClienteAsync(int id)
        {
            await Task.Delay(150);
            var cliente = _clientes.FirstOrDefault(c => c.IdCliente == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }

        public async Task<IEnumerable<ClienteDTO>> SearchClientesAsync(string searchTerm)
        {
            await Task.Delay(100);
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _clientes;

            searchTerm = searchTerm.ToLower();
            return _clientes.Where(c =>
                c.Nome.ToLower().Contains(searchTerm) ||
                c.CPF.Contains(searchTerm) ||
                (c.Email?.ToLower().Contains(searchTerm) ?? false) ||
                (c.Telefone?.Contains(searchTerm) ?? false)
            );
        }
    }
}