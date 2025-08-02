using System.ComponentModel.DataAnnotations;

namespace GestaoClinica.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "Somente números! CPF deve ter no máximo 11 caracteres")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data de Nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        [StringLength(15, ErrorMessage = "Telefone deve ter no máximo 15 caracteres")]
        public string Telefone { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Email deve ter no máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Observações devem ter no máximo 500 caracteres")]
        public string Observacoes { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;

        public int? EnderecoId { get; set; }

        public EnderecoDTO? Endereco { get; set; }

        // Propriedades calculadas para exibição
        public string EnderecoCompleto => Endereco != null
            ? $"{Endereco.Logradouro}, {Endereco.Numero} - {Endereco.Cidade}/{Endereco.Uf}"
            : "Sem endereço cadastrado";

        public int Idade => DateTime.Now.Year - DataNascimento.Year;

        public string Status => Ativo ? "Ativo" : "Inativo";
    }
}