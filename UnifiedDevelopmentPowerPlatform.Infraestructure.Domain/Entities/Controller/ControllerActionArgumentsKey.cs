using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller;

/// <summary>
/// Controller action arguments key for UNIFIED DEVELOPMENT POWER PLATFORM.
/// </summary>
[ComplexType]
public static class ControllerActionArgumentsKey
{
    /// <summary>
    /// Metadata.
    /// </summary>
    /// <paramref name="metadata"/ The name of property is the name of parameter in the controller.>
    public const string Metadata = "metadata";

    /// <summary>
    /// Tables data.
    /// </summary>
    /// <paramref name="tablesdata"/ The name of property is the name of parameter in the controller.>
    public const string Tablesdata = "tablesdata";
}