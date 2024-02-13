using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.OpenApi
{
    [ComplexType]
    /// <summary>
    /// Documentation about the licenses of API.
    /// </summary>
    public static class OpenApiLicense
    {
        /// <summary>
        /// Name.
        /// </summary>
        public static string Name => "Information about the license.";

        /// <summary>
        /// Url.
        /// </summary>
        public static string Url => "https://claudiomildo.net/license";
    }
}