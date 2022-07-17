using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IfrsDocs.Domain;
using ifrsDocs.Repository;

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
            return services;
        }
    }
}
