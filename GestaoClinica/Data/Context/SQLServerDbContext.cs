using GestaoClinica.Entities;
using Microsoft.EntityFrameworkCore;
using GestaoClinica.Entities.GestaoClinica.Entities;

namespace GestaoClinica.Data.Context
{
    public class SQLServerDbContext : DbContext
    {
        public SQLServerDbContext(DbContextOptions options) : base(options)
        {
        }
        // public DbSet<Agendamento> agendamentos { get; set; }
         public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Clientes { get; set;}
        // public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        //public DbSet<Pessoa> pessoas { get; set; }
         public DbSet<Servico> Servicos { get; set; }
        // public DbSet<StatusAgenda> statusAgendas { get; set; }

    }
}
