<<<<<<< HEAD
﻿namespace GestaoClinica.Entities

    {
=======
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoClinica.Entities
{
    [Table("Servico")]
>>>>>>> ac67329f4093a79c13eaedcd153bc0aeceaf6951
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int DuracaoEstimada { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime UltimaAtualizacao { get; set; } = DateTime.UtcNow;

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        //public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public Servico()
        {
        }

        public Servico(int idServico)
        {
            IdServico = idServico;
        }
    }
}
