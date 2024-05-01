using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign
{
    [ComplexType]
    /// <summary>
    /// Domain is the directory for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class DirectoryDomain
    {
        /// <summary>
        /// Domain.
        /// </summary>
        public static string Domain => string.Format("{0}3-Domain", Path.DirectorySeparatorChar);

        /// <summary>
        /// Interfaces.
        /// </summary>
        public static string Interfaces => string.Format("{0}Interfaces", Path.DirectorySeparatorChar);

        /// <summary>
        /// Entities.
        /// </summary>
        public static string Entities => string.Format("{0}Entities", Path.DirectorySeparatorChar);
    }
}