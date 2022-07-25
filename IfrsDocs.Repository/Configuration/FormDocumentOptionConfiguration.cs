using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace IfrsDocs.Repository.Configuration
{
    public class FormDocumentOptionConfiguration : IEntityTypeConfiguration<FormDocumentOption>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FormDocumentOption> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("FormDocumentOption").HasKey(ur => new { ur.FormId, ur.DocumentOptionId }); ;
            builder.Property(p => p.FormId).HasColumnName("FormId");
            builder.Property(p => p.DocumentOptionId).HasColumnName("DocumentOptionId");

            builder.HasOne(bc => bc.Form)
                   .WithMany(b => b.FormDocumentOptions)
                   .HasForeignKey(bc => bc.FormId);

            builder.HasOne(bc => bc.DocumentOption)
                    .WithMany(b => b.FormDocumentOptions)
                    .HasForeignKey(bc => bc.DocumentOptionId);
        }
    }
}
