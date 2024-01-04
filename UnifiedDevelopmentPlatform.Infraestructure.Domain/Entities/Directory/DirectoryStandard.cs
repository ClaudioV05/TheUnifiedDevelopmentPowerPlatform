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
        public static string App { get; } = "\\App";

        /// <summary>
        /// Backend.
        /// </summary>
        public static string Backend { get; } = "\\Backend";

        /// <summary>
        /// Frontend.
        /// </summary>
        public static string Frontend { get; } = "\\Frontend";

        /// <summary>
        /// Configuration.
        /// </summary>
        public static string Configuration { get; } = "\\_Configuration";

        /// <summary>
        /// Json.
        /// </summary>
        public static string Json { get; } = "\\Json";

        /// <summary>
        /// Xml.
        /// </summary>
        public static string Xml { get; } = "\\Xml";

        /// <summary>
        /// Log.
        /// </summary>
        public static string Log { get; } = "\\Log";
    }
}