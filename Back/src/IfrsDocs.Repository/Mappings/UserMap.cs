﻿using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfrsDocs.Repository.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("User");
            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Description).HasColumnName("Description");
            builder.Property(p => p.Email).HasColumnName("Email");
            builder.Property(p => p.CPF).HasColumnName("CPF");
            builder.Property(p => p.Password).HasColumnName("Password");
            builder.Property(p => p.RoleId).HasColumnName("RoleId");
            builder.Property(p => p.CreateDate).HasColumnName("CreateDate");
            builder.Property(p => p.UpdateDate).HasColumnName("UpdateDate");
        }
    }
}