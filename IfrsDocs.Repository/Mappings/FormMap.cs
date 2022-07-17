using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace IfrsDocs.Repository.Mappings
{
    public class FormMap : IEntityTypeConfiguration<Form>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Form> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Form");
            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.UserId).HasColumnName("UserId");
            builder.Property(p => p.Email).HasColumnName("Email");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.CPF).HasColumnName("CPF");
            builder.Property(p => p.CourseString).HasColumnName("CourseString");
            builder.Property(p => p.ReceiveDocumentTypeId).HasColumnName("ReceiveDocumentTypeId");
            builder.Property(p => p.DocumentTypeId).HasColumnName("DocumentTypeId");
            builder.Property(p => p.Status).HasColumnName("Status");
            builder.Property(p => p.CreateDate).HasColumnName("CreateDate");
            builder.Property(p => p.UpdateDate).HasColumnName("UpdateDate");
            builder.Property(p => p.CreateBy).HasColumnName("CreateBy");
            builder.Property(p => p.UpdateBy).HasColumnName("UpdateBy");
        }
    }
}
