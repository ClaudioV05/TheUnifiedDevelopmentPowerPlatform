using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory
{
    [ComplexType]
    /// <summary>
    /// Application is the directory for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class DirectoryApplication
    {
        /// <summary>
        /// Application.
        /// </summary>
        public static string Application => "\\2-Application";

        /// <summary>
        /// Interfaces.
        /// </summary>
        public static string Interfaces => "\\Interfaces";

        /// <summary>
        /// Services.
        /// </summary>
        public static string Services => "\\Services";
    }
}