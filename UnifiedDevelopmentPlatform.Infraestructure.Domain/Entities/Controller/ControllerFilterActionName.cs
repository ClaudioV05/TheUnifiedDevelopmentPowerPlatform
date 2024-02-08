using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller
{
    [ComplexType]
    /// <summary>
    /// Controller filter action name for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class ControllerFilterActionName
    {
        /// <summary>
        /// Database schema.
        /// </summary>
        public const string DatabaseSchema = "databaseSchema";

        /// <summary>
        /// Metadata.
        /// </summary>
        public const string Metadata = "metadata";
    }
}