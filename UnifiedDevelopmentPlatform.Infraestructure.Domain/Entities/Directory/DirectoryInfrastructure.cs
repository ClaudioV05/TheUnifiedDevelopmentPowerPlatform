using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory
{
    [ComplexType]
    /// <summary>
    /// Infrastructure is the directory for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class DirectoryInfrastructure
    {
        /// <summary>
        /// Infrastructure.
        /// </summary>
        public static string Infrastructure { get; } = "\\4-Infrastructure";

        /// <summary>
        /// Cross Cutting.
        /// </summary>
        public static string CrossCutting { get; } = "\\CrossCutting";

        /// <summary>
        /// Data.
        /// </summary>
        public static string Data { get; } = "\\Data";
    }
}