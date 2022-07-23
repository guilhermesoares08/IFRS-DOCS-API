using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace IfrsDocs.Repository.Configuration
{
    public class DocumentOptionConfiguration : IEntityTypeConfiguration<DocumentOption>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DocumentOption> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("DocumentOption");
            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.DocumentTypeId).HasColumnName("DocumentTypeId");
            builder.Property(p => p.FieldType).HasColumnName("FieldType");
            builder.Property(p => p.Description).HasColumnName("Description");
            builder.Property(p => p.CreateDate).HasColumnName("CreateDate");
            builder.Property(p => p.UpdateDate).HasColumnName("UpdateDate");
        }
    }
}
