using IfrsDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IfrsDocs.Repository.DataContext
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
            
        }
    }
        
}
