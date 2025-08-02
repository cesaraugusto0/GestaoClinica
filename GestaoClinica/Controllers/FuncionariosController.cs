// Controllers/FuncionariosController.cs
using Microsoft.AspNetCore.Mvc;
using GestaoClinica.Services.Interfaces;
using GestaoClinica.Entities;
using System.Net.Mime;

namespace GestaoClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionariosController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
            var funcionarios = await _funcionarioService.ListarFuncionarioAsync();
            return Ok(funcionarios);
        }

        /// <summary>
        /// Busca funcionario por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
            try
            {
                var funcionario = await _funcionarioService.ObterFuncionarioPorIdAsync(id);
                return Ok(funcionario);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Funcionario com ID {id} não encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno.", error = ex.Message });
            }
        }

        /// <summary>
        /// Cria um novo funcionario
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> PostFuncionario([FromBody] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _funcionarioService.AdicionarAsync(funcionario);
                return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.IdFuncionario }, funcionario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao salvar funcionario.", error = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um funcionario existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(int id, [FromBody] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // ✅ Força o funcionario a usar o ID da URL
                funcionario.IdFuncionario = id;

                await _funcionarioService.AtualizarAsync(funcionario);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao atualizar funcionario.",
                    error = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }

        /// <summary>
        /// Exclui um funcionario
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            try
            {
                await _funcionarioService.ExcluirAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Funcionario com ID {id} não encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao excluir.", error = ex.Message });
            }
        }
    }
}