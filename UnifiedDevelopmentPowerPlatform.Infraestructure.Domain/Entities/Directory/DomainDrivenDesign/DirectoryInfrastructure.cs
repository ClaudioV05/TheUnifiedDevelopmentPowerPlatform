using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;

[ComplexType]
/// <summary>
/// Infrastructure is the directory for UNIFIED DEVELOPMENT PLATFORM.
/// </summary>
public static class DirectoryInfrastructure
{
    /// <summary>
    /// Infrastructure.
    /// </summary>
    public static string Infrastructure => string.Format("{0}4-Infrastructure", Path.DirectorySeparatorChar);

    /// <summary>
    /// Cross Cutting.
    /// </summary>
    public static string CrossCutting => string.Format("{0}CrossCutting", Path.DirectorySeparatorChar);

    /// <summary>
    /// Data.
    /// </summary>
    public static string Data => string.Format("{0}Data", Path.DirectorySeparatorChar);
}