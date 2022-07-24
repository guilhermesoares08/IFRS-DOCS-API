using IfrsDocs.Domain.Entities.Enums;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace IfrsDocs.Domain.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this System.Enum enumerationValue)
        {
            Type type = enumerationValue.GetType();
            MemberInfo member = type.GetMembers().FirstOrDefault(w => w.Name == System.Enum.GetName(type, enumerationValue));
            var attribute = member?.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description != null ? attribute.Description : enumerationValue.ToString();
        }

        public static T GetEnumValue<T>(this string description)
        {
            var type = typeof(T);
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException("This type is not a enum.");

            try
            {
                T res = (T)System.Enum.Parse(typeof(T), description, true);
                if (!System.Enum.IsDefined(typeof(T), res))
                    return default(T);

                return res;
            }
            catch
            {
                return default(T);
            }

        }

        public static char? GetCharDescription(this System.Enum enumerationValue)
        {
            if (enumerationValue == null)
            {
                return null;
            }

            string descirption = enumerationValue.GetDescription();
            if (!string.IsNullOrEmpty(descirption))
            {
                return descirption.ToCharArray().FirstOrDefault();
            }
            return null;
        }
    }
}
