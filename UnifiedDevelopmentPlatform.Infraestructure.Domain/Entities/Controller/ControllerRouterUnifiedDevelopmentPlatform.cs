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
        /// Route metadata all tables name.
        /// </summary>
        public const string RouterMetadataAllTablesName = "/MetadataAllTablesName";

        /// <summary>
        /// Route metadata all fields name.
        /// </summary>
        public const string RouterMetadataAllFieldsName = "/MetadataAllFieldsName";
    }
}