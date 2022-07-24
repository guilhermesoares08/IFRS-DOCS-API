using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfrsDocs.Repository.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SetEnumStringConverter(this ModelBuilder modelBuilder)
        {
            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => (Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType).IsEnum);

            foreach (var property in properties)
                property.SetProviderClrType(typeof(string));
        }
    }
}
