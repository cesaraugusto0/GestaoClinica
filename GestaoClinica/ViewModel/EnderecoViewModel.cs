using System.ComponentModel.DataAnnotations;

namespace GestaoClinica.ViewModel
{
    public class EnderecoViewModel
    {
        [StringLength(255, ErrorMessage = "Logradouro deve ter no máximo 255 caracteres")]
        public string Logradouro { get; set; } = string.Empty;

        [StringLength(30, ErrorMessage = "Número deve ter no máximo 30 caracteres")]
        public string Numero { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Complemento deve ter no máximo 100 caracteres")]
        public string Complemento { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Cidade deve ter no máximo 100 caracteres")]
        public string Cidade { get; set; } = string.Empty;

        [StringLength(2, ErrorMessage = "UF deve ter 2 caracteres")]
        public string Uf { get; set; } = string.Empty;

        [StringLength(9, ErrorMessage = "CEP deve ter no máximo 9 caracteres, formato XXXXX-XXX")]
        public string Cep { get; set; } = string.Empty;
    }
}