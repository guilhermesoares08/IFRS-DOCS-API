using IfrsDocs.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using IfrsDocs.Domain.Extensions;

namespace ManualInvoice.Data.Converters
{
    //public class FormStatusConverter : ValueConverter<FormStatus?, int>
    //{
    //    //public FormStatusConverter(ConverterMappingHints mappingHints = null)
    //    //    : base(x => Serialize(x), x => Deserialize(x), mappingHints)
    //    //{
    //    //}

    //    //public static int Serialize(FormStatus? formStatus)
    //    //{
    //    //    return (int)formStatus.Value;
    //    //}

    //    //public static FormStatus? Deserialize(int value)
    //    //{
    //    //    new EnumToStringConverter
    //    //    switch (value)
    //    //    {
    //    //        case (int) FormStatus.EmAndamento
    //    //            return FormStatus.EmAndamento;
    //    //        case (int)FormStatus.Pendente
    //    //            return FormStatus.Pendente;
    //    //        case "R":
    //    //            return DellBaseFlagType.Rollup;
    //    //        default:
    //    //            return DellBaseFlagType.Unknown;
    //    //    }
    //    //}
    //}
}
