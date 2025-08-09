namespace GestaoClinica.DTO;

public class PessoaDTO
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
}

public class PessoaResumoDTO
{
    public string Nome { get; set; }
}