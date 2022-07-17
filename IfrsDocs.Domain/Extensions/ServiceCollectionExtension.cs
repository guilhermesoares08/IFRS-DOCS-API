using IfrsDocs.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IfrsDocs.Domain
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<,>));            
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IDocumentOptionService, DocumentOptionService>();
            services.AddScoped<IFormService, FormService>();

            return services;
        }
    }
}
