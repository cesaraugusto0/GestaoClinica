using GestaoClinica.DTO;

namespace GestaoClinica.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<FuncionarioAgendamentoReportDTO>> GetTop5FuncionariosComMaisAgendamentosAsync();
        Task<IEnumerable<ServicoAgendamentoReportDTO>> GetTop5ServicosMaisAgendadosAsync();
    }
}
