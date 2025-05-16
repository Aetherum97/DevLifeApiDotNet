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
            var allTypes = assembly.GetTypes().ToList();

            var serviceImplementations = allTypes
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"))
                .ToList();

            var serviceInterfaces = serviceImplementations
                .SelectMany(c => c.GetInterfaces())
                .Where(i => i.Name.EndsWith("Service"))
                .Distinct()
                .ToList();

            foreach (var serviceInterface in serviceInterfaces)
            {
                var implementation = serviceImplementations
                    .FirstOrDefault(c => serviceInterface.IsAssignableFrom(c));

                if (implementation != null)
                {
                    services.AddScoped(serviceInterface, implementation);
                }
                else
                {
                    Console.WriteLine($"No implementation found for {serviceInterface.Name}");
                }
            }
        }
    }
}
