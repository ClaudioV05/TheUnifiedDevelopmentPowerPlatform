using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller
{
    [ComplexType]
    /// <summary>
    /// Controller Router for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public abstract class ControllerRouter
    {
        public const string RouteController = "[Controller]";
        public const string RouteMetadataAllTablesName = "/MetadataAllTablesName";
        public const string RouteMetadataAllFieldsName = "/MetadataAllFieldsName";
    }
}