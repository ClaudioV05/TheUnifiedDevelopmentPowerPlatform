﻿using Microsoft.AspNetCore.Cors.Infrastructure;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions;

public static class CorsExtensions
{
    /// <summary>
    /// Configure cors.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureCors(this IServiceCollection services)
    {
        var corsBuilder = new CorsPolicyBuilder();
        corsBuilder.AllowAnyHeader();
        corsBuilder.AllowAnyMethod();
        corsBuilder.AllowAnyOrigin();

        services.AddCors(options => { options.AddDefaultPolicy(corsBuilder.Build()); });
    }
}