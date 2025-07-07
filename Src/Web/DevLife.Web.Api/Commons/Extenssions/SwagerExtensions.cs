using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.Reflection;

namespace DevLife.Web.Api.Commons.Extenssions;

public static class SwagerExtensions
{
    public static IApplicationBuilder UseSwaggerExtensions(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }

    public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                        Scheme = "Bearer",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    }, new List<string>()
                },
            });
        });

        return services;
    }

    public class DefaultValuesSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null)
                return;

            foreach (var prop in context.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var attr = prop.GetCustomAttribute<DefaultValueAttribute>();
                if (attr == null)
                    continue;

                var name = char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1);
                if (!schema.Properties.ContainsKey(name))
                    continue;

                var defaultValue = attr.Value;
                switch (defaultValue)
                {
                    case string s:
                        schema.Properties[name].Default = new OpenApiString(s);
                        break;
                    case int i:
                        schema.Properties[name].Default = new OpenApiInteger(i);
                        break;
                }
            }
        }
    }

}
