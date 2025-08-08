namespace GestaoClinica.DTO;

public class AgendamentoDTO
{
    public int IdAgendamento { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public string HoraInicio { get; set; }
    public string HoraFinm { get; set; }
    public int DuracaoAtendimento { get; set; }
    public string? Observacoes { get; set; }
    public int ClienteId { get; set; }
    public int ServicoId { get; set; }
    public int FuncionarioId { get; set; }
    public ClienteDTO? Cliente { get; set; }
    public ServicoDTO? Servico { get; set; }
    public FuncionarioDTO? Funcionario { get; set; }
    public string StatusAgenda { get; set; } // Usando string para simplificar a serialização
}

public class AgendamentoCreateDTO
{
    public int IdAgendamento { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public int DuracaoAtendimento { get; set; }
    public string? Observacoes { get; set; }
    public int ClienteId { get; set; }
    public int ServicoId { get; set; }
    public int FuncionarioId { get; set; }
    public string StatusAgenda { get; set; }
}