using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller
{
    [ComplexType]
    /// <summary>
    /// Controller Router for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class ControllerRouterUnifiedDevelopmentPlatform
    {
        /// <summary>
        /// Route controller.
        /// </summary>
        public const string RouterController = "[Controller]";

        /// <summary>
        /// Routing to controller tables and fields of metadata.
        /// </summary>
        public const string RouterTablesAndFieldsOfMetadata = "/TablesAndFieldsOfMetadata";

        /// <summary>
        /// Route metadata all fields name.
        /// </summary>
        public const string RouterMetadataAllFieldsName = "/MetadataAllFieldsName";
    }
}