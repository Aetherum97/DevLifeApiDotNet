using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace DevLife.Application
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            RegisterValidators(services);
            RegisterServices(services);
            RegisterHelpers(services);
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

        private static void RegisterValidators(this IServiceCollection services)
        {
            var validatorBaseType = typeof(AbstractValidator<>);
            var assembly = Assembly.GetExecutingAssembly();

            var validatorTypes = assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface && t.BaseType != null
                            && t.BaseType.IsGenericType
                            && t.BaseType.GetGenericTypeDefinition() == validatorBaseType)
                .ToList();

            foreach (var validatorType in validatorTypes)
            {
                var modelType = validatorType.BaseType!.GetGenericArguments()[0];
                var interfaceType = typeof(IValidator<>).MakeGenericType(modelType);

                services.AddScoped(interfaceType, validatorType);
            }
        }

        private static void RegisterHelpers(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var allTypes = assembly.GetTypes().ToList();

            var serviceImplementations = allTypes
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Helper"))
                .ToList();

            var serviceInterfaces = serviceImplementations
                .SelectMany(c => c.GetInterfaces())
                .Where(i => i.Name.EndsWith("Helper"))
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
