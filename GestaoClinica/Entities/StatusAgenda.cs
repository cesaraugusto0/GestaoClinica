namespace GestaoClinica.Entities
{
    public class StatusAgenda
    {
        public int IdStatusAgenda { get; set; }
        public string NomeStatus { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; } = DateTime.UtcNow;

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public StatusAgenda()
        {
        }

        public StatusAgenda(int idStatusAgenda)
        {
            IdStatusAgenda = idStatusAgenda;
        }
    }
}
