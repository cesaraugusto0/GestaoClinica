namespace GestaoClinica.Entities
{
    public class Servico
    {
        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int DuracaoEstimada { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public Servico()
        {
        }

        public Servico(int idServico)
        {
            IdServico = idServico;
        }
    }
}
