using Microsoft.Extensions.DependencyInjection.Extensions;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions.ServiceCollection;

public static class DependenciesExtensions
{
    /// <summary>
    /// Configure dependencies.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureDependencies(this IServiceCollection services)
    {
        services.TryAddTransient<FilterActionContextController>();
        services.TryAddTransient<FilterActionContextLog>();
        services.TryAddTransient<FilterActionContextControllerInformation>();
        services.TryAddTransient<FilterActionContextMetadata<MetadataOwner>>();
        services.TryAddTransient<FilterActionContextTablesdata<MetadataOwner>>();
    }
}