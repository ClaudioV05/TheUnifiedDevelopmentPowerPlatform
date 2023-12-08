namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller
{
    /// <summary>
    /// Controller direction router.
    /// </summary>
    public abstract class ControllerRouter
    {
        public const string RouteController = "[Controller]";
        public const string RouteMetadataAllTablesName = "/MetadataAllTablesName";
        public const string RouteMetadataAllFieldsName = "/MetadataAllFieldsName";
    }
}