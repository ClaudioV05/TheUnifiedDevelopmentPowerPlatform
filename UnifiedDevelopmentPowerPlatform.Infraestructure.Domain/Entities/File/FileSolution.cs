using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;

/// <summary>
/// File for the solution.
/// </summary>
[ComplexType]
public static class FileSolution
{
    /// <summary>
    /// A solution name.
    /// </summary>
    public static string App => "App";
}