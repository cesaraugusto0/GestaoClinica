using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoClinica.Entities
{
    [Table("Cliente")]
    public class Cliente : Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }

        public int? EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        //public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public Cliente()
        {
        }

        public Cliente(int idCliente)
        {
            IdCliente = idCliente;
        }
    }
}
