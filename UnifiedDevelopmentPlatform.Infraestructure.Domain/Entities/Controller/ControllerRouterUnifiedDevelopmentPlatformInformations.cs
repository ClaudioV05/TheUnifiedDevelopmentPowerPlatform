using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller
{
    [ComplexType]
    /// <summary>
    /// Controller Router for UNIFIED DEVELOPMENT PLATFORM INFORMATION.
    /// </summary>
    public static class ControllerRouterUnifiedDevelopmentPlatformInformations
    {
        /// <summary>
        /// Route controller.
        /// </summary>
        public const string RouterController = "[Controller]";

        /// <summary>
        /// Route databases.
        /// </summary>
        public const string RouterDatabases = "/Databases";

        /// <summary>
        /// Route forms.
        /// </summary>
        public const string RouterForms = "/Forms";
    }
}