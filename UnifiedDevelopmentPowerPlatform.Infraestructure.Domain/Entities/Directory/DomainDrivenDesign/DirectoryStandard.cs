using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign
{
    [ComplexType]
    /// <summary>
    /// Standard is the directory default for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class DirectoryStandard
    {
        /// <summary>
        /// App.
        /// </summary>
        public static string App => string.Format("{0}App", Path.DirectorySeparatorChar);

        /// <summary>
        /// Backend.
        /// </summary>
        public static string Backend => string.Format("{0}Backend", Path.DirectorySeparatorChar);

        /// <summary>
        /// Frontend.
        /// </summary>
        public static string Frontend => string.Format("{0}Frontend", Path.DirectorySeparatorChar);

        /// <summary>
        /// Configuration.
        /// </summary>
        public static string Configuration => string.Format("{0}_Configuration", Path.DirectorySeparatorChar);

        /// <summary>
        /// Json.
        /// </summary>
        public static string Json => string.Format("{0}Json", Path.DirectorySeparatorChar);

        /// <summary>
        /// Xml.
        /// </summary>
        public static string Xml => string.Format("{0}Xml", Path.DirectorySeparatorChar);

        /// <summary>
        /// Log.
        /// </summary>
        public static string Log => string.Format("{0}Log", Path.DirectorySeparatorChar);
    }
}