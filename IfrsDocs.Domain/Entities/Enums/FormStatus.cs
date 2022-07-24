using System.ComponentModel;

namespace IfrsDocs.Domain.Entities.Enums
{
    public enum FormStatus
    {
        [Description("Pendente")]
        Pendente,
        [Description("Em Andamento")]
        EmAndamento,
        [Description("Atendida")]
        Atendida,
        [Description("Aguardando Retirada")]
        AguardandoRetirada,
        [Description("Cancelada")]
        Cancelada,
    }
}
