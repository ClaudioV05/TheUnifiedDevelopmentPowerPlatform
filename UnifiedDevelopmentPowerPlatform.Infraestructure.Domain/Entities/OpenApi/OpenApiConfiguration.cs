using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.OpenApi
{
    /// <summary>
    /// Configuration about the OpenApi.
    /// </summary>
    [ComplexType]
    public static class OpenApiConfiguration
    {
        /// <summary>
        /// Endpoint.
        /// </summary>
        public static string Endpoint => "/swagger/v1/swagger.json";

        /// <summary>
        /// Style Sheet.
        /// </summary>
        public static string StyleSheet => "/swagger-ui/custom.css";

        /// <summary>
        /// Open Api HTML.
        /// </summary>
        public static string Html => "/swagger/index.html";
        
    }
}