using GestaoClinica.Entities;

namespace GestaoClinica.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> ListarPessoasAsync();
    }
}
