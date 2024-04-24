using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory
{
    [ComplexType]
    /// <summary>
    /// Presentation is the directory for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class DirectoryPresentation
    {
        /// <summary>
        /// Presentation.
        /// </summary>
        public static string Presentation => string.Format("{0}1-Presentation", Path.DirectorySeparatorChar);

        /// <summary>
        /// Properties.
        /// </summary>
        public static string Properties => string.Format("{0}Properties", Path.DirectorySeparatorChar);

        /// <summary>
        /// Controllers.
        /// </summary>
        public static string Controllers => string.Format("{0}Controllers", Path.DirectorySeparatorChar);

        /// <summary>
        /// Extensions.
        /// </summary>
        public static string Extensions => string.Format("{0}Extensions", Path.DirectorySeparatorChar);

        /// <summary>
        /// Filters.
        /// </summary>
        public static string Filters => string.Format("{0}Filters", Path.DirectorySeparatorChar);

        /// <summary>
        /// Models.
        /// </summary>
        public static string Models => string.Format("{0}Models", Path.DirectorySeparatorChar);

        /// <summary>
        /// Swagger.
        /// </summary>
        public static string Swagger => string.Format("{0}Swagger", Path.DirectorySeparatorChar);
    }
}