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
        /// Log.
        /// </summary>
        public static string Log => "\\_log";

        /// <summary>
        /// The database schema.
        /// </summary>
        public static string DatabaseSchema => "\\_databaseschema";

        /// <summary>
        /// The identifier the form.
        /// </summary>
        public static string IdentifierTheForm => "\\_identifierform";
    }
}