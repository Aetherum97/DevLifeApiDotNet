using System;
using DevLife.Application.Commons.Interfaces.Services;

namespace DevLife.Web.Api.Commons.Services;

public static class ServiceRegistration
{

    public static IServiceCollection AddPresentationWebApiLayer(this IServiceCollection services)
    {

        services.RegisterServices();
        return services;
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
    }
}

