namespace GestaoClinica.Entities
{
    public class Cliente:Pessoa
    {
        public int IdCliente { get; set; }
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public Cliente()
        {
        }

        public Cliente(int idCliente)
        {
            IdCliente = idCliente;
        }
    }
}
