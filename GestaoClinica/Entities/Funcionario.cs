using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoClinica.Entities
{
    [Table("Funcionario")]
    public class Funcionario:Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFuncionario { get; set; }
        public string SenhaHash { get; set; }
        public string Perfil { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; } = DateTime.UtcNow;

        // public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public Funcionario()
        {
        }

        public Funcionario(int idFuncionario)
        {
            IdFuncionario = idFuncionario;
        }
    }
}
