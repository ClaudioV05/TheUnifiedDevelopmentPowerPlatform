﻿using Microsoft.OpenApi.Models;
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
        services.AddSwaggerGen(config =>
        {
            config.SchemaFilter<OpenApiIgnoreFilter>();
            config.DocumentFilter<OpenApiDocumentation>();
            config.OperationFilter<OpenApiParameters>();
            config.DescribeAllParametersInCamelCase();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}{FileExtension.Xml}";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (!File.Exists(xmlPath))
            {
                File.Create(xmlPath).Dispose();
            }
            
            config.IncludeXmlComments(xmlPath);

            config.AddSecurityDefinition("Bearer", new()
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Description = "JWT Authorization header using the Bearer scheme."
            });
        });
    }
}