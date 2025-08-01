// Controllers/ClientesController.cs
using Microsoft.AspNetCore.Mvc;
using GestaoClinica.Services.Interfaces;
using GestaoClinica.Entities;
using System.Net.Mime;

namespace GestaoClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteService.ListarClienteAsync();
                return Ok(new { message = "Clientes listados com sucesso!", data = clientes });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao listar clientes.", error = ex.Message });
            }
        }

        /// <summary>
        /// Busca cliente por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var cliente = await _clienteService.ObterClientePorIdAsync(id);
                return Ok(new { message = $"Cliente com ID {id} encontrado com sucesso!", data = cliente });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Cliente com ID {id} não encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao buscar cliente.", error = ex.Message });
            }
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> PostCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                await _clienteService.AdicionarAsync(cliente);
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.IdCliente }, 
                    new { message = "Cliente criado com sucesso!", data = cliente });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar cliente.", error = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um cliente existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                // ✅ Força o cliente a usar o ID da URL
                cliente.IdCliente = id;

                await _clienteService.AtualizarAsync(cliente);
                return Ok(new { message = $"Cliente com ID {id} atualizado com sucesso!" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao atualizar cliente.",
                    error = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }

        /// <summary>
        /// Exclui um cliente
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                await _clienteService.ExcluirAsync(id);
                return Ok(new { message = $"Cliente com ID {id} excluído com sucesso!" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Cliente com ID {id} não encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao excluir cliente.", error = ex.Message });
            }
        }
    }
}