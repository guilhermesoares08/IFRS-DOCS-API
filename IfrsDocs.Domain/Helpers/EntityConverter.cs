using IfrsDocs.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IfrsDocs.Domain.Helpers
{
    public static class EntityConverter
    {
        public static TTarget CopyProperties<TTarget, TSource>(TSource source)
            where TTarget : new()
        {
            TTarget target = new TTarget();

            PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
            PropertyInfo[] targetProperties = typeof(TTarget).GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo targetProperty = targetProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);

                if (targetProperty != null && targetProperty.CanWrite)
                {
                    object value = sourceProperty.GetValue(source);

                    if (targetProperty.PropertyType.IsEnum && value != null)
                    {
                        Type enumType = Enum.GetUnderlyingType(targetProperty.PropertyType);
                        value = Enum.ToObject(targetProperty.PropertyType, Convert.ChangeType(value, enumType));
                    }

                    targetProperty.SetValue(target, value);
                }
            }

            return target;
        }

        public static Form ConvertToForm(RequestNewFormDto dto)
        {
            Form f = new Form()
            {
                UserId = dto.UserId,
                CourseId = dto.CourseId,
                ReceiveDocumentType = dto.ReceiveDocumentType,
                DocumentType = dto.DocumentType,
                Status = dto.Status,
                UpdateDate = dto.UpdateDate,
                Note = dto.Note,
                FormDocumentOptions = new List<FormDocumentOption>()
            };

            foreach (var fdo in dto.FormDocumentOptions)
            {
                f.FormDocumentOptions.Add(new FormDocumentOption()
                {
                    DocumentOptionId = fdo.DocumentOptionId
                });
            }

            return f;
        }
    }
}
