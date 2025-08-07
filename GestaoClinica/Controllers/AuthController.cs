// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using GestaoClinica.Services;
using GestaoClinica.Data.Context;
using GestaoClinica.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly SQLServerDbContext _context;

    public AuthController(TokenService tokenService, SQLServerDbContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    public class LoginRequest
    {
        [Required]
        public string Usuario { get; set; } // Aqui será o Email
        [Required]
        public string Senha { get; set; }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var funcionario = await _context.Funcionarios
            .FirstOrDefaultAsync(f => f.Email == request.Usuario && f.SenhaHash == request.Senha && f.Ativo);

        if (funcionario != null)
        {
            var token = _tokenService.GerarToken(funcionario.Email);

            return Ok(new
            {
                token,
                funcionarioId = funcionario.IdFuncionario,
                nome = funcionario.Nome,
                perfil = funcionario.Perfil
            });
        }

        return Unauthorized(new { message = "Usuário ou senha inválidos" });
    }
}
