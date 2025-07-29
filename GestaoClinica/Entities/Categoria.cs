namespace GestaoClinica.Entities
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DataTime UltimaAtualizacao { get; set; }

        public ICollection<Servico> Servicos { get; set; } = new List<Servico>();

        public Categoria()
        {
        }

        public Categoria(int idCategoria)
        {
            IdCategoria = idCategoria;
        }
    }
}
