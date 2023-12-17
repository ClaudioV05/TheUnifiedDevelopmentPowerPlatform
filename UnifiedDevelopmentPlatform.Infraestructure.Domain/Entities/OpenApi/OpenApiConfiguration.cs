namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.OpenApi
{
    /// <summary>
    /// Configuration about the OpenApi.
    /// </summary>
    public abstract class OpenApiConfiguration
    {
        public const string ENDPOINT = "/swagger/v1/swagger.json";
        public const string STYLE_SHEET = "/swagger-ui/custom.css";
    }
}