using GestaoClinica.Entities;

namespace GestaoClinica.Repository.Interfaces
{
    public interface IAgendamentoRepository
    {

        Task<IEnumerable<Agendamento>> ListarAgendamentosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<Agendamento>> ListarAgendamentosPorClienteAsync(int idCliente);
        Task<IEnumerable<Agendamento>> ListarAgendamentosPorFuncionarioAsync(int idFuncionario);
        Task<IEnumerable<Agendamento>> ListarAgendamentosPorServicoAsync(int idServico);
        Task<IEnumerable<Agendamento>> ListarAgendamentosAsync();
        Task<Agendamento> ObterAgendamentoPorIdAsync(int id);
        Task AdicionarAsync(Agendamento agendamento);
        Task AtualizarAsync(Agendamento agendamento);
        Task ExcluirAsync(int id);
    }
}
