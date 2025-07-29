namespace GestaoClinica.Entities
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DataTime UltimaAtualizacao { get; set; }

        public ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

        public Endereco() 
        {
        }

        public Endereco(int idEndereco)
        {
            IdEndereco = idEndereco;
        }
    }
}
