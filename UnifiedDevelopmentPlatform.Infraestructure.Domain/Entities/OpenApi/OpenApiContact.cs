using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.OpenApi
{
    [ComplexType]
    /// <summary>
    /// Documentation about the contacts of API.
    /// </summary>
    public static class OpenApiContact
    {
        /// <summary>
        /// Name.
        /// </summary>
        public static string Name { get; } = "CLAUDIOMILDO VENTURA";

        /// <summary>
        /// Email.
        /// </summary>
        public static string Email { get; } = "claudiomildo@hotmail.com";

        /// <summary>
        /// Url.
        /// </summary>
        public static string Url { get; } = "https://www.claudiomildo.net";
    }
}