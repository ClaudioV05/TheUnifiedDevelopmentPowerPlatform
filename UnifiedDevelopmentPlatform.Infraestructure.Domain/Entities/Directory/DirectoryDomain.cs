using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory
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
        public static string Domain => "\\3-Domain";

        /// <summary>
        /// Interfaces.
        /// </summary>
        public static string Interfaces => "\\Interfaces";

        /// <summary>
        /// Entities.
        /// </summary>
        public static string Entities => "\\Entities";
    }
}