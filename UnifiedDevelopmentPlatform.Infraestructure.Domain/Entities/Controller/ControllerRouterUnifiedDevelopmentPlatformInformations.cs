using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

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
        public const string RouterParametersOfDatabases = "/ParametersOfDatabases";

        /// <summary>
        /// Route forms.
        /// </summary>
        public const string RouterParametersOfForms = "/ParametersOfForms";

        /// <summary>
        /// Route development enviroment.
        /// </summary>
        public const string RouterParametersOfDevelopmentEnviroment = "/ParametersOfDevelopmentEnviroment";

        /// <summary>
        /// Route databases engine.
        /// </summary>
        public const string RouterParametersOfDatabasesEngine = "/ParametersOfDatabasesEngine";

        /// <summary>
        /// Route architectures.
        /// </summary>
        public const string RouterParametersOfArchitectures = "/ParametersOfArchitectures";

        /// <summary>
        /// Route informations.
        /// </summary>
        public const string RouterParametersOfInformation = "/ParametersOfInformations";
    }
}