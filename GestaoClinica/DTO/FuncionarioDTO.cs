namespace GestaoClinica.DTO;

public class FuncionarioDTO : PessoaDTO
{
    public int IdFuncionario { get; set; }
    public string Perfil { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime UltimaAtualizacao { get; set; }
    public int? EnderecoId { get; set; }
    public EnderecoDTO? Endereco { get; set; }
        
    // SenhaHash não está incluída por segurança
}

// DTO para criação de Funcionario
public class FuncionarioCreateDTO : PessoaDTO
{
    public string Senha { get; set; }  // Diferente da entidade (não é hash ainda)
    public string Perfil { get; set; }
    public bool Ativo { get; set; } = true;
    public int? EnderecoId { get; set; }
}

// DTO para atualização de Funcionario
public class FuncionarioUpdateDTO
{
    public string? Nome { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Cpf { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? Senha { get; set; }  // Opcional para atualização
    public string? Perfil { get; set; }
    public bool? Ativo { get; set; }
    public int? EnderecoId { get; set; }
}

// DTO para login (pode ser útil)
public class FuncionarioLoginDTO
{
    public string Email { get; set; }
    public string Senha { get; set; }
}