using GestaoClinica.Entities;
using GestaoClinica.Entities.GestaoClinica.Entities;
using GestaoClinica.Services.Implementations;
using GestaoClinica.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace GestaoClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoService _servicoService;

        public ServicosController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpGet]
        public async Task<ActionResult> GetServicos()
        {
            try
            {
                var servicos = await _servicoService.ListarServicoAsync();

                var resultado = servicos.Select(s => new
                {
                    s.IdServico,
                    s.NomeServico,
                    s.Descricao,
                    s.Preco,
                    s.DuracaoEstimada,
                    s.Ativo,
                    s.DataCriacao,
                    s.UltimaAtualizacao,
                    Categoria = s.Categoria == null ? null : new
                    {
                        Id = s.Categoria.IdCategoria,
                        s.Categoria.NomeCategoria,
                        s.Categoria.DataCriacao,
                        s.Categoria.UltimaAtualizacao
                    }

                }
                ).ToList();
                return Ok(new
                {
                    message = "Servico listados com sucesso!",
                    data = resultado
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao listar clientes.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> GetServico(int id)
        {
            try
            {
                var cliente = await _servicoService.ObterServicoPorIdAsync(id);
                return Ok(new { message = $"Servico com ID {id} encontrado com sucesso!", data = cliente });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Servico com ID {id} não encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao buscar cliente.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostCliente([FromBody] Servico servico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                await _servicoService.AdicionarAsync(servico);
                return CreatedAtAction(nameof(GetServico), new { id = servico.IdServico },
                    new { message = "Cliente criado com sucesso!", data = servico });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar servico.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, [FromBody] Servico servico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {

                servico.IdServico = id;

                await _servicoService.AtualizarAsync(servico);
                return Ok(new { message = $"Servico com ID {id} atualizado com sucesso!" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao atualizar servico.",
                    error = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            try
            {
                await _servicoService.ExcluirAsync(id);
                return Ok(new { message = $"Servico com ID {id} excluído com sucesso!" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Servico com ID {id} não encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao excluir servico.", error = ex.Message });
            }
        }
    }
}
