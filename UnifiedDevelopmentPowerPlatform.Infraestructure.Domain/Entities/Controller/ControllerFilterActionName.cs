using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller
{
    /// <summary>
    /// Controller filter action name for UNIFIED DEVELOPMENT POWER PLATFORM.
    /// </summary>
    [ComplexType]
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

        /// <summary>
        /// Tables data.
        /// </summary>
        public const string Tablesdata = "tablesdata";
    }
}