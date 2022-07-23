using System.ComponentModel;

namespace IfrsDocs.Domain.Entities.Enums
{
    public enum FormStatus
    {
        [Description("Pendente")]
        Pendente = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,
        [Description("Atendida")]
        Atendida = 3,
        [Description("Aguardando Retirada")]
        AguardandoRetirada = 4,
        [Description("Cancelada")]
        Cancelada = 5
    }
}
