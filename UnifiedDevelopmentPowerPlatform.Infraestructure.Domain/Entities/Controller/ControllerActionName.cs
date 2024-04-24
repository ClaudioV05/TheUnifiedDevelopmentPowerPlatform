using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller
{
    [ComplexType]
    /// <summary>
    /// Controller Action Name for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class ControllerActionName
    {
        /// <summary>
        /// MetadataAllTablesName.
        /// </summary>
        public static string MetadataAllTablesName => "MetadataAllTablesName";

        /// <summary>
        /// MetadataAllFieldsName.
        /// </summary>
        public static string MetadataAllFieldsName => "MetadataAllFieldsName";
    }
}