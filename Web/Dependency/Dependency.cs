using Application.Extensions;
using Application.Mappings;
using System.Reflection;

namespace API.Dependency
{
    public static class Dependency
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services, IConfiguration configuration, Assembly applicationAssembly)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddSingleton(provider =>
            {
                var env = provider.GetRequiredService<IWebHostEnvironment>();
                return new FileStorageOptions
                {
                    WebRootPath = env.WebRootPath
                };
            });

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
