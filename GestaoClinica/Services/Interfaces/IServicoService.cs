using GestaoClinica.Entities;
using GestaoClinica.Entities.GestaoClinica.Entities;

namespace GestaoClinica.Services.Interfaces
{
    public interface IServicoService
    {
        Task<IEnumerable<Servico>> ListarServicoAsync();
        Task<Servico> ObterServicoPorIdAsync(int id);
        Task AdicionarAsync(Servico servico);
        Task AtualizarAsync(Servico servico);
        Task ExcluirAsync(int id);
    }
}
