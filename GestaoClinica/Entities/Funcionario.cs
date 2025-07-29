namespace GestaoClinica.Entities
{
    public class Funcionario:Pessoa
    {
        public int IdFuncionario { get; set; }
        public string SenhaHash { get; set; }
        public string Perfil { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DataTime UltimaAtualizacao { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public Funcionario()
        {
        }

        public Funcionario(int idFuncionario)
        {
            IdFuncionario = idFuncionario;
        }
    }
}
