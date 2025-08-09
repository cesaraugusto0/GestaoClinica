using GestaoClinica.DTO;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Implementations;

namespace GestaoClinica.Services.Interfaces
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
    }
}
