using System.ComponentModel;

namespace IfrsDocs.Domain.Entities.Enums
{
    public enum ReceiveDocumentType
    {
        [Description("Documento(s) online por e-mail")]
        ByEmail,
        [Description("Documento(s) impresso retirado no Setor de Ensino")]
        Impresso
    }
}
