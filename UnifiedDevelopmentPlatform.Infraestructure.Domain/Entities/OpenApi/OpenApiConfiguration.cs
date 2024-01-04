using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.OpenApi
{
    [ComplexType]
    /// <summary>
    /// Configuration about the OpenApi.
    /// </summary>
    public static class OpenApiConfiguration
    {
        /// <summary>
        /// Endpoint.
        /// </summary>
        public static string Endpoint { get; } = "/swagger/v1/swagger.json";

        /// <summary>
        /// Style Sheet.
        /// </summary>
        public static string StyleSheet { get; } = "/swagger-ui/custom.css";
    }
}