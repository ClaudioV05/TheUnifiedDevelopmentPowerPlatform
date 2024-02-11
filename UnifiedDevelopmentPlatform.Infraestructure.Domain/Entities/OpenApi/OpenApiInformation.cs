using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.OpenApi
{
    [ComplexType]
    /// <summary>
    /// Documentation about the informations of API.
    /// </summary>
    public static class OpenApiInformation
    {
        /// <summary>
        /// Version.
        /// </summary>
        public static string Version => "v1";

        /// <summary>
        /// Title.
        /// </summary>
        public static string Title => "UNIFIED DEVELOPMENT PLATFORM";

        /// <summary>
        /// Description.
        /// </summary>
        public static string Description => "Generator of Class to C#";

        /// <summary>
        /// Terms of service.
        /// </summary>
        public static string TermsOfService => "https://claudiomildo.net/terms";
    }
}