using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace DevLife.Application
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            RegisterServices(services);
            return services;
        }

        private static void RegisterServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var serviceInterfaces = assembly
                .GetTypes()
                .Where(t => t.IsInterface && t.Name.EndsWith("Service"))
                .ToList();

            var serviceImplementations = assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"))
                .ToList();

            foreach (var serviceInterface in serviceInterfaces)
            {
                var implementation = serviceImplementations
                    .FirstOrDefault(c => serviceInterface.IsAssignableFrom(c));
                
                services.AddScoped(serviceInterface, implementation!);
            }
        }
    }
}
