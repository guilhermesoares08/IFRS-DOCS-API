﻿using IfrsDocs.Services;
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
            services.AddScoped<IFormCanceledService, FormCanceledService>();
            services.AddScoped<IFormDocumentOptionService, FormDocumentOptionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
