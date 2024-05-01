using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller;

/// <summary>
/// Controller Router for UNIFIED DEVELOPMENT POWER PLATFORM.
/// </summary>
[ComplexType]
public static class ControllerRouterUnifiedDevelopmentPowerPlatform
{
    /// <summary>
    /// Route controller.
    /// </summary>
    public const string RouterController = "[Controller]";

    /// <summary>
    /// Routing to controller metadata.
    /// </summary>
    public const string RouterMetadata = "/Metadata";

    /// <summary>
    ///  Routing to controller tables data.
    /// </summary>
    public const string RouterTablesdata = "/Tablesdata";
}