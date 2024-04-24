using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File
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
        /// The identifier of the forms.
        /// </summary>
        public static string IdForm => "\\_idForm";

        /// <summary>
        /// The identifier of the development environments.
        /// </summary>
        public static string IdDevelopmentEnvironment => "\\_idDevelopmentEnvironment";

        /// <summary>
        /// The identifier of the databases.
        /// </summary>
        public static string IdDatabases => "\\_idDatabases";

        /// <summary>
        /// The identifier of the databases engine.
        /// </summary>
        public static string IdDatabasesEngine => "\\_idDatabasesEngine";

        /// <summary>
        /// The identifier of the architecture patterns.
        /// </summary>
        public static string IdArchitecturePatterns => "\\_idArchitecturePatterns";
    }
}