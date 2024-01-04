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
        public static string App { get; } = "\\_app";

        /// <summary>
        /// Configuration.
        /// </summary>
        public static string Configuration { get; } = "\\_configuration";

        /// <summary>
        /// Log.
        /// </summary>
        public static string Log { get; } = "\\_log";
    }
}