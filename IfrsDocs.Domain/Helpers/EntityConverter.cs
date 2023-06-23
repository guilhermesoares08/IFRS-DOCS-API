using System;
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
    }
}
