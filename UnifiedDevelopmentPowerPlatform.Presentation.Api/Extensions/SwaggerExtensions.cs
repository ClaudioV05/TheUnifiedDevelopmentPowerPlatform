using System.Reflection;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.OpenApi;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions;

public static class SwaggerExtensions
{
    /// <summary>
    /// Configure swagger.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SchemaFilter<OpenApiIgnoreFilter>();
            c.DocumentFilter<OpenApiDocumentation>();
            c.OperationFilter<OpenApiParameters>();
            c.DescribeAllParametersInCamelCase();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}{FileExtension.Xml}";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath);
            }
            else
            {
                File.Create(xmlPath).Dispose();
                c.IncludeXmlComments(xmlPath);
            }
        });
    }
}