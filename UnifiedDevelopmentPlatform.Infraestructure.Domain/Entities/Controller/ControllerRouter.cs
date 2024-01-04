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
        /// RouteController.
        /// </summary>
        public const string RouteController = "[Controller]";

        /// <summary>
        /// RouteMetadataAllTablesName.
        /// </summary>
        public const string RouteMetadataAllTablesName = "/MetadataAllTablesName";

        /// <summary>
        /// RouteMetadataAllFieldsName.
        /// </summary>
        public const string RouteMetadataAllFieldsName = "/MetadataAllFieldsName";
    }
}