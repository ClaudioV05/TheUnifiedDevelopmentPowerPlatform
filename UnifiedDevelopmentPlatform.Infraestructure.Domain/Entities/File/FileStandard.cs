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
        /// The identifier of the database schema.
        /// </summary>
        public static string IdDatabaseSchema => "\\_idDatabaseSchema";

        /// <summary>
        /// The identifier of the form.
        /// </summary>
        public static string IdForm => "\\_idForm";

        /// <summary>
        /// The identifier of the development environment.
        /// </summary>
        public static string IdDevelopmentEnvironment => "\\_idDevelopmentEnvironment";
    }
}