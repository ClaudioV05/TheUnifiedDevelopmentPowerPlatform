using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory
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
        public static string Presentation => "\\1-Presentation";

        /// <summary>
        /// Properties.
        /// </summary>
        public static string Properties => "\\Properties";

        /// <summary>
        /// Controllers.
        /// </summary>
        public static string Controllers => "\\Controllers";

        /// <summary>
        /// Extensions.
        /// </summary>
        public static string Extensions => "\\Extensions";

        /// <summary>
        /// Filters.
        /// </summary>
        public static string Filters => "\\Filters";

        /// <summary>
        /// Models.
        /// </summary>
        public static string Models => "\\Models";

        /// <summary>
        /// Swagger.
        /// </summary>
        public static string Swagger => "\\Swagger";
    }
}