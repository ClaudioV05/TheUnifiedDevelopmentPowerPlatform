using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller
{
    [ComplexType]
    /// <summary>
    /// Controller Router for UNIFIED DEVELOPMENT PLATFORM INFORMATION.
    /// </summary>
    public static class ControllerRouterUnifiedDevelopmentPowerPlatformParameters
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
        public const string RouterParametersOfArchitecturePatterns = "/ParametersOfArchitecturePatterns";

        /// <summary>
        /// Route informations.
        /// </summary>
        public const string RouterParametersOfInformation = "/ParametersOfInformations";
    }
}