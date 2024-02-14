using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File
{
    [ComplexType]
    /// <summary>
    /// File for the standard.
    /// </summary>
    public static class FileStandard
    {
        /// <summary>
        /// App.
        /// </summary>
        public static string App => "\\_app";

        /// <summary>
        /// Configuration.
        /// </summary>
        public static string Configuration => "\\_configuration";

        /// <summary>
        /// Log.
        /// </summary>
        public static string Log => "\\_log";

        /// <summary>
        /// Database schema.
        /// </summary>
        public static string DatabaseSchema => "\\_databaseschema";
    }
}