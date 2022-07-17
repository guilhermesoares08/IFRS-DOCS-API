using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace IfrsDocs.Repository.Mappings
{
    public class FormDocumentOptionMap : IEntityTypeConfiguration<FormDocumentOption>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FormDocumentOption> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("FormDocumentOption");
            builder.Property(p => p.FormId).HasColumnName("FormId");
            builder.Property(p => p.DocumentOptionId).HasColumnName("DocumentOptionId");
        }
    }
}
