using GestaoClinica.Entities;

namespace GestaoClinica.Repository.Interfaces
{
    public interface IServicoRepository
    {
        Task<IEnumerable<Servico>> ListarServicoAsync();
        Task AdicionarAsync(Servico servico);
        Task AtualizarAsync(Servico servico);
        Task ExcluirAsync(Servico servico);
    }
}
