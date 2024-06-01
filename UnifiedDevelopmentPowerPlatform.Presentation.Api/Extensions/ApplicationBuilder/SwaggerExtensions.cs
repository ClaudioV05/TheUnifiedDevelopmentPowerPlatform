using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.OpenApi;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions.ApplicationBuilder;

public static class SwaggerExtensions
{
    /// <summary>
    /// Configure swagger.
    /// </summary>
    /// <param name="app"></param>
    public static void ConfigureSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(OpenApiConfiguration.Endpoint, OpenApiInformation.Description);
            options.InjectStylesheet(OpenApiConfiguration.StyleSheet);
            options.EnableTryItOutByDefault();
        });

        app.Use(async (context, next) =>
        {
            if (context.Request.Path == $"/{nameof(UnifiedDevelopmentPowerPlatform)}")
            {
                context.Response.Redirect(OpenApiConfiguration.Html);
                return;
            }

            await next();
        });
    }
}