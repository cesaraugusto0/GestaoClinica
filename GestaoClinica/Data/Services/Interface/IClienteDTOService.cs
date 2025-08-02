using GestaoClinica.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoClinica.Data.Services.Interfaces
{
    public interface IClienteDTOService
    {
        Task<IEnumerable<ClienteDTO>> GetAllClientesAsync();
        Task<ClienteDTO?> GetClienteByIdAsync(int id);
        Task<int> CreateClienteAsync(ClienteDTO cliente);
        Task UpdateClienteAsync(ClienteDTO cliente);
        Task DeleteClienteAsync(int id);
        Task<IEnumerable<ClienteDTO>> SearchClientesAsync(string searchTerm);
    }
}