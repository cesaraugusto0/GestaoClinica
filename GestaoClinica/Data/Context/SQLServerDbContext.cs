using GestaoClinica.Entities;
using GestaoClinica.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoClinica.Data.Context
{
    public class SQLServerDbContext : DbContext
    {
        public SQLServerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Agendamento> Agendamentos { get; set; }
        // public DbSet<Categoria> categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set;}
        // public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        //public DbSet<Pessoa> pessoas { get; set; }
         public DbSet<Servico> Servicos { get; set; }
        // public DbSet<StatusAgenda> statusAgendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agendamento>()
                .Property(a => a.StatusAgenda)
                .HasConversion(new EnumToStringConverter<StatusAgendaEnum>());
        }
    }
}
