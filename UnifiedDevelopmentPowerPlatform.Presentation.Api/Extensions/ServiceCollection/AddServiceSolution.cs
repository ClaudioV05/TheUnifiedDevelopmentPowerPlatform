using UnifiedDevelopmentPowerPlatform.Presentation.Api.OpenApi;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions.ServiceCollection;

public static class AddServiceSolution
{
    /// <summary>
    /// Configure services.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServiceSolution(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddControllers(config => config.Conventions.Add(new OpenApiHideControllerConvention()));

        services.ConfigureMvc();

        services.ConfigureCors();

        services.ConfigureSwagger();

        services.ConfigureDependencies();

        services.ConfigureDependencies(nameof(UnifiedDevelopmentPowerPlatform));
    }
}