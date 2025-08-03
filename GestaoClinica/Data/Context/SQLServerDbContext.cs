using GestaoClinica.Entities;
using GestaoClinica.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using GestaoClinica.Entities.GestaoClinica.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoClinica.Data.Context
{
    public class SQLServerDbContext : DbContext
    {
        public SQLServerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agendamento>()
                .Property(a => a.StatusAgenda)
                .HasConversion(new EnumToStringConverter<StatusAgendaEnum>());
        }
    }
}
