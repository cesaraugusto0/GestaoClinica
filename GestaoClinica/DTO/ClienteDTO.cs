namespace GestaoClinica.DTO;

public class ClienteDTO : PessoaDTO
{
    public int IdCliente { get; set; }
    public string Observacoes { get; set; }
    public bool Ativo { get; set; }
    public int? EnderecoId { get; set; }
    public EnderecoDTO? Endereco { get; set; }
}