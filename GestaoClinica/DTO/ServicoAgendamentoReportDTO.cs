namespace GestaoClinica.DTO
{
    public class ServicoAgendamentoReportDTO
    {
        public int ServicoId { get; set; }
        public string NomeServico { get; set; }
        public string Categoria { get; set; }
        public int TotalAgendamentos { get; set; }
    }
}