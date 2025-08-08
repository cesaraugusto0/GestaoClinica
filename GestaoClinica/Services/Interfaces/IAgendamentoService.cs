using GestaoClinica.DTO;
using GestaoClinica.Entities;

namespace GestaoClinica.Services.Interfaces
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<Agendamento>> ListarAgendamentosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<Agendamento>> ListarAgendamentosPorClienteAsync(int idCliente);
        Task<IEnumerable<Agendamento>> ListarAgendamentosPorFuncionarioAsync(int idFuncionario);
        Task<IEnumerable<Agendamento>> ListarAgendamentosPorServicoAsync(int idServico);
        Task<IEnumerable<AgendamentoDTO>> ListarAgendamentosAsync();
        Task<Agendamento> ObterAgendamentoPorIdAsync(int id);
        Task AdicionarAsync(AgendamentoCreateDTO agendamento);
        Task AtualizarAsync(Agendamento agendamento);
        Task ExcluirAsync(int id);
    }
}
