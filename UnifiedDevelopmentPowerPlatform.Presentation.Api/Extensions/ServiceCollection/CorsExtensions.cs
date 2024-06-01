namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions.ServiceCollection;

public static class CorsExtensions
{
    /// <summary>
    /// Configure Cross-Origin Resource Sharing (CORS).
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowOrigin",
                builder =>
                {
                    builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
        });
    }
}