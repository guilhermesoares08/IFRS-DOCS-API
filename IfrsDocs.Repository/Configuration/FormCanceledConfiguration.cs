using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace IfrsDocs.Repository.Configuration
{
    public class FormCanceledConfiguration : IEntityTypeConfiguration<FormCanceled>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FormCanceled> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("FormCanceled");
            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.FormId).HasColumnName("FormId");
            builder.Property(p => p.CanceledDate).HasColumnName("CanceledDate");
            builder.Property(p => p.CanceledBy).HasColumnName("CanceledBy");
        }
    }
}
