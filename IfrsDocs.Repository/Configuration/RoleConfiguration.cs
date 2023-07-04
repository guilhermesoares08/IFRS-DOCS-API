using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfrsDocs.Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Role");
            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedNever().IsRequired();
            builder.Property(p => p.Description).HasColumnName("Description"); 

            builder.HasMany(e => e.Users).WithOne(r => r.Role).HasForeignKey(r => r.RoleId).IsRequired();
        }
    }
}
