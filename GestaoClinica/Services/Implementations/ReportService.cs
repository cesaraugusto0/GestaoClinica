using GestaoClinica.DTO;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;

namespace GestaoClinica.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public ReportService(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<IEnumerable<FuncionarioAgendamentoReportDTO>> GetTop5FuncionariosComMaisAgendamentosAsync()
        {
            return await _agendamentoRepository.GetTop5FuncionariosComMaisAgendamentosAsync();
        }

        public async Task<IEnumerable<ServicoAgendamentoReportDTO>> GetTop5ServicosMaisAgendadosAsync()
        {
            return await _agendamentoRepository.GetTop5ServicosMaisAgendadosAsync();
        }
    }
}
