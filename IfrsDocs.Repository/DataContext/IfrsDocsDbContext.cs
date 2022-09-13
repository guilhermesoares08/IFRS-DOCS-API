using IfrsDocs.Domain;
using IfrsDocs.Domain.Entities.Enums;
using IfrsDocs.Repository.Configuration;
using IfrsDocs.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Reflection;

namespace IfrsDocs.Repository
{
    public class IfrsDocsDbContext : DbContext
    {
        public IfrsDocsDbContext(DbContextOptions<IfrsDocsDbContext> options) : base(options) { }
        public DbSet<Course> Course { get; set; }
        public DbSet<DocumentOption> DocumentOption { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<FormCanceled> FormCanceled { get; set; }
        public DbSet<FormDocumentOption> FormDocumentOption { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SetEnumStringConverter();
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentOptionConfiguration());
            modelBuilder.ApplyConfiguration(new FormCanceledConfiguration());
            modelBuilder.ApplyConfiguration(new FormDocumentOptionConfiguration());
            modelBuilder.ApplyConfiguration(new FormConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }      
    }        
}
