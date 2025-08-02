using System.Net.Mime;
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Implementations;
using GestaoClinica.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController (ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategorias()
        {
            try
            {
                var categorias = await _categoriaService.ListarCategoriasAsync();

                var resultado = categorias.Select(c => new
                {
                    c.IdCategoria,
                    c.NomeCategoria,
                    c.DataCriacao,
                    c.UltimaAtualizacao
                }).ToList();

                return Ok(new
                {
                    message = "Categorias Listadas com sucesso",
                    data = resultado
                });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostCliente([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                await _categoriaService.AdicionarAsync(categoria);
                return CreatedAtAction(nameof(GetCategorias), new { id = categoria.IdCategoria },
                    new { message = "Categoria criada com sucesso!", data = categoria });
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

        [HttpPut("{idCategoria}")]
        public async Task<IActionResult> PutCliente(int idCategoria, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                // ✅ Força o cliente a usar o ID da URL
                categoria.IdCategoria = idCategoria;

                await _categoriaService.AtualizarAsync(categoria);
                return Ok(new { message = $"Categoria com ID {idCategoria} atualizado com sucesso!" });
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
    }
}
