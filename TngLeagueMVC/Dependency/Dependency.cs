using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using TngLeague.Application.Mappings;

namespace API.Dependency
{
    public static class Dependency
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services, IConfiguration configuration, Assembly applicationAssembly)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            var types = applicationAssembly.DefinedTypes
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any() && t.Name.EndsWith("Service"));
            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().FirstOrDefault();
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, type);
                }
            }
            return services;
        }
    }
}
