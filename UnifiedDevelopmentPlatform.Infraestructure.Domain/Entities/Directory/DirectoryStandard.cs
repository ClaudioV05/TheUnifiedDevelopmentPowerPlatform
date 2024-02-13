using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory
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
        public static string App => "\\App";

        /// <summary>
        /// Backend.
        /// </summary>
        public static string Backend => "\\Backend";

        /// <summary>
        /// Frontend.
        /// </summary>
        public static string Frontend => "\\Frontend";

        /// <summary>
        /// Configuration.
        /// </summary>
        public static string Configuration => "\\_Configuration";

        /// <summary>
        /// Json.
        /// </summary>
        public static string Json => "\\Json";

        /// <summary>
        /// Xml.
        /// </summary>
        public static string Xml => "\\Xml";

        /// <summary>
        /// Log.
        /// </summary>
        public static string Log => "\\Log";
    }
}