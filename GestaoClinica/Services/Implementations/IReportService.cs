using GestaoClinica.DTO;

namespace GestaoClinica.Services.Implementations
{
    public interface IReportService
    {
        Task<IEnumerable<FuncionarioAgendamentoReportDTO>> GetTop5FuncionariosComMaisAgendamentosAsync();
    }
}
