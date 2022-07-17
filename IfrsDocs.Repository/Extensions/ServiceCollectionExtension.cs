using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IfrsDocs.Domain;

namespace IfrsDocs.Repository
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIfrsDocsDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IfrsDocsDbContext>(x => x.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IDocumentOptionRepository, DocumentOptionRepository>();
            services.AddScoped<IFormRepository, FormRepository>();
            return services;
        }
    }
}
