namespace GestaoClinica.Entities
{
    public abstract class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; }
        
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
