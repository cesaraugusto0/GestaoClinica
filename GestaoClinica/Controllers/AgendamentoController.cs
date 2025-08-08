using GestaoClinica.Entities;
using GestaoClinica.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using GestaoClinica.DTO;

namespace GestaoClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentosController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        /// <summary>
        /// Lista todos os agendamentos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAgendamentos()
        {
            try
            {
                var agendamentos = await _agendamentoService.ListarAgendamentosAsync();
                return Ok(new
                {
                    message = "Agendamentos listados com sucesso!",
                    data = agendamentos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao listar agendamentos.", error = ex.Message });
            }
        }

        /// <summary>
        /// Busca agendamento por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
        {
            try
            {
                var agendamento = await _agendamentoService.ObterAgendamentoPorIdAsync(id);
                return Ok(new { message = $"Agendamento encontrado com sucesso!", data = agendamento });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Agendamento não encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao buscar agendamento.", error = ex.Message });
            }
        }

        /// <summary>
        /// Cria um novo agendamento
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> PostAgendamento([FromBody] AgendamentoCreateDTO agendamento)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                await _agendamentoService.AdicionarAsync(agendamento);
                return CreatedAtAction(nameof(GetAgendamento), new { id = agendamento.IdAgendamento },
                    new { message = "Agendamento criado com sucesso!", data = agendamento });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar agendamento.", error = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um agendamento existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento(int id, [FromBody] Agendamento agendamento)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                agendamento.IdAgendamento = id;
                await _agendamentoService.AtualizarAsync(agendamento);
                return Ok(new { message = $"Agendamento atualizado com sucesso!" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao atualizar agendamento.",
                    error = ex.Message,
                });
            }
        }

        /// <summary>
        /// Exclui um agendamento
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(int id)
        {
            try
            {
                await _agendamentoService.ExcluirAsync(id);
                return Ok(new { message = $"Agendamento excluído com sucesso!" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Agendamento não encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao excluir agendamento.", error = ex.Message });
            }
        }

        /// <summary>
        /// Busca agendamentos por um período de datas.
        /// </summary>
        [HttpGet("porPeriodo")]
        public async Task<ActionResult> GetAgendamentosPorPeriodo([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            try
            {
                var agendamentos = await _agendamentoService.ListarAgendamentosPorPeriodoAsync(dataInicio, dataFim);
                return Ok(new { message = "Agendamentos encontrados com sucesso!", data = agendamentos });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar agendamentos por período.", error = ex.Message });
            }
        }

        /// <summary>
        /// Busca agendamentos por ID do cliente.
        /// </summary>
        [HttpGet("porCliente/{idCliente}")]
        public async Task<ActionResult> GetAgendamentosPorCliente(int idCliente)
        {
            try
            {
                var agendamentos = await _agendamentoService.ListarAgendamentosPorClienteAsync(idCliente);
                return Ok(new { message = "Agendamentos encontrados com sucesso!", data = agendamentos });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar agendamentos por cliente.", error = ex.Message });
            }
        }

        /// <summary>
        /// Busca agendamentos por ID do funcionário.
        /// </summary>
        [HttpGet("porFuncionario/{idFuncionario}")]
        public async Task<ActionResult> GetAgendamentosPorFuncionario(int idFuncionario)
        {
            try
            {
                var agendamentos = await _agendamentoService.ListarAgendamentosPorFuncionarioAsync(idFuncionario);
                return Ok(new { message = "Agendamentos encontrados com sucesso!", data = agendamentos });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar agendamentos por funcionário.", error = ex.Message });
            }
        }

        /// <summary>
        /// Busca agendamentos por ID do serviço.
        /// </summary>
        [HttpGet("porServico/{idServico}")]
        public async Task<ActionResult> GetAgendamentosPorServico(int idServico)
        {
            try
            {
                var agendamentos = await _agendamentoService.ListarAgendamentosPorServicoAsync(idServico);
                return Ok(new { message = "Agendamentos encontrados com sucesso!", data = agendamentos });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar agendamentos por serviço.", error = ex.Message });
            }
        }
    }
}
