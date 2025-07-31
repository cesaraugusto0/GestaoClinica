using GestaoClinica.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Data.Context
{
    public class SQLServerDbContext : DbContext
    {
        public SQLServerDbContext(DbContextOptions options) : base(options)
        {
        }
        // public DbSet<Agendamento> agendamentos { get; set; }
        // public DbSet<Categoria> categorias { get; set; }
        public DbSet<Cliente> clientes { get; set;}
        // public DbSet<Endereco> enderecos { get; set; }
        // public DbSet<Funcionario> funcionarios { get; set; }
        //public DbSet<Pessoa> pessoas { get; set; }
        // public DbSet<Servico> servicos { get; set; }
        // public DbSet<StatusAgenda> statusAgendas { get; set; }

    }
}
