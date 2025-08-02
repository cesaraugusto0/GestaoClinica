using System.ComponentModel;

namespace GestaoClinica.Entities.Enums
{
    public enum StatusAgendaEnum
    {
        [Description("Horário Marcado")]
        HorarioMarcado = 1,

        [Description("Confirmado")]
        Confirmado = 2,

        [Description("Cliente Chegou")]
        ClienteChegou = 3,

        [Description("Em Atendimento")]
        EmAtendimento = 4,

        [Description("Concluído")]
        Concluido = 5,

        [Description("Cliente Faltou")]
        ClienteFaltou = 6,

        [Description("Cancelado")]
        Cancelado = 7
    }
}
