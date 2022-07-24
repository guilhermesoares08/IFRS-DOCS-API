using System.ComponentModel;

namespace IfrsDocs.Domain.Entities.Enums
{
    public enum DocumentType
    {
        [Description("Histórico e/ou Ementas")]
        Historico,
        [Description("Atestados e/ou Comprovantes")]
        Comprovante
    }
}
