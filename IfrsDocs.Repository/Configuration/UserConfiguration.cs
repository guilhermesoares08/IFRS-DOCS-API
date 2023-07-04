using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfrsDocs.Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("User");
            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Login).HasColumnName("Description");
            builder.Property(p => p.Email).HasColumnName("Email");
            builder.Property(p => p.CPF).HasColumnName("CPF");
            builder.Property(p => p.Password).HasColumnName("Password");
            builder.Property(p => p.RoleId).HasColumnName("RoleId");
            builder.Property(p => p.CreateDate).HasColumnName("CreateDate");
            builder.Property(p => p.UpdateDate).HasColumnName("UpdateDate");

            builder.HasOne(p => p.Role).WithOne().HasForeignKey<User>(p => p.RoleId);
        }
    }
}
