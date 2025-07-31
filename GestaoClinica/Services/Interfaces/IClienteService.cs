using GestaoClinica.Entities;

namespace GestaoClinica.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ListarClientesAsync();
    }
}
