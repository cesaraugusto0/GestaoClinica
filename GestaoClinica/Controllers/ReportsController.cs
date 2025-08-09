using GestaoClinica.DTO;
using GestaoClinica.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace GestaoClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("top5-funcionarios-agendamentos")]
        public async Task<ActionResult<IEnumerable<FuncionarioAgendamentoReportDTO>>> GetTop5FuncionariosComMaisAgendamentos()
        {
            var result = await _reportService.GetTop5FuncionariosComMaisAgendamentosAsync();
            return Ok(result);
        }
    }
}
