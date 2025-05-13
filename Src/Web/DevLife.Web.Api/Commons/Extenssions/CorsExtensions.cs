using System;

namespace DevLife.Web.Api.Commons.Extenssions;

public static class CorsExtensions
{
    public static IServiceCollection AddCorsExtenssions(this IServiceCollection services)
    {
        return services.AddCors(opt =>
        {
            opt.AddPolicy("development", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });
    }

    public static IApplicationBuilder UseDevelopementCors(this IApplicationBuilder app)
    {
        return app.UseCors("development");
    }

}
