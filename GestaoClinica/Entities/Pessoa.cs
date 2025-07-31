namespace GestaoClinica.Entities
{
    public class Pessoa
    {
        public Pessoa()
        {
        }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; }
        
        public int? EnderecoId { get; set; }
        // public Endereco Endereco { get; set; }
    }
}
