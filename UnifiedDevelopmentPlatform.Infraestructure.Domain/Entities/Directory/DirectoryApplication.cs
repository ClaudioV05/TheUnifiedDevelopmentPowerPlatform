using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory
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
        public static string Application => string.Format("{0}2-Application", Path.DirectorySeparatorChar);

        /// <summary>
        /// Interfaces.
        /// </summary>
        public static string Interfaces => string.Format("{0}Interfaces", Path.DirectorySeparatorChar);

        /// <summary>
        /// Services.
        /// </summary>
        public static string Services => string.Format("{0}Services", Path.DirectorySeparatorChar);
    }
}