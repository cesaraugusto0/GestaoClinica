namespace GestaoClinica.Entities
{
    public abstract class Pessoa
    {
        public Pessoa()
        {
        }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; } // Pode tirar esse ? ou quebra a aplicação?
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; } = DateTime.UtcNow;
        

    }
}
