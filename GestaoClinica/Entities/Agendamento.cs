using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestaoClinica.Entities.Enums;

namespace GestaoClinica.Entities
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgendamento { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public int DuracaoAtendimento { get; set; }
        public string? Observacoes { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; } = DateTime.UtcNow;
        public int ClienteId { get; set; }
        public int ServicoId { get; set; }
        public int FuncionarioId { get; set; }
        public Cliente? Cliente { get; set; }
        public Servico? Servico { get; set; }
        public Funcionario? Funcionario { get; set; }
        public StatusAgendaEnum StatusAgenda { get; set; }
    }
}
