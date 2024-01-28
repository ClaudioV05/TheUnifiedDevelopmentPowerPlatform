using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller
{
    [ComplexType]
    /// <summary>
    /// Controller Router for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class ControllerRouter
    {
        /// <summary>
        /// Route controller.
        /// </summary>
        public const string RouteController = "[Controller]";

        /// <summary>
        /// Route metadata all tables name.
        /// </summary>
        public const string RouteMetadataAllTablesName = "/MetadataAllTablesName";

        /// <summary>
        /// Route metadata all fields name.
        /// </summary>
        public const string RouteMetadataAllFieldsName = "/MetadataAllFieldsName";
    }
}