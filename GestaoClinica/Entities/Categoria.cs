using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoClinica.Entities
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; }

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
