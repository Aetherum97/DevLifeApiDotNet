using System;
using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Web.Api.Commons.Services;


namespace DevLife.Web.Api;

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

