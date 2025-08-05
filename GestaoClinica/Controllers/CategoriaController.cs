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

        public CategoriaController(ICategoriaService categoriaService)
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
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao listar categoria.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostCategoria([FromBody] Categoria categoria)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {
                // Atualiza o ID da categoria com o valor da URL
                categoria.IdCategoria = id;

                await _categoriaService.AtualizarAsync(categoria);
                return Ok(new { message = $"Categoria com ID {id} atualizado com sucesso!" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao atualizar categoria.",
                    error = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }

        [HttpDelete("{idCategoria}")]
        public async Task<IActionResult> DeleteCategoria(int idCategoria)
        {
            try
            {
                await _categoriaService.ExcluirAsync(idCategoria);
                return Ok(new { message = $"Categoria com ID {idCategoria} excluída com sucesso!" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Categoria com ID {idCategoria} não encontrada." });
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("vinculada", StringComparison.OrdinalIgnoreCase))
            {
                // Erro personalizado de vinculação
                return BadRequest(new
                {
                    message = "Não é possível excluir esta categoria.",
                    error = ex.Message
                });
            }
            catch (Exception ex) when (ex.InnerException?.Message.Contains("REFERENCE constraint", StringComparison.OrdinalIgnoreCase) ?? false)
            {
                // Captura erro do banco: FK violada
                return BadRequest(new
                {
                    message = "Não é possível excluir esta categoria.",
                    error = "A categoria está vinculada a um ou mais serviços e não pode ser excluída."
                });
            }
            catch (Exception ex)
            {
                // Qualquer outro erro (inesperado)
                return StatusCode(500, new
                {
                    message = "Erro ao excluir categoria.",
                    error = "Ocorreu um erro interno no servidor.",
                    // Só mostre ex.Message em desenvolvimento
                });
            }
        }


    }
}
