using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service development environment.
    /// </summary>
    public interface IServiceDevelopmentEnvironment
    {
        /// <summary>
        /// Select parameters the kinds of development enviroment.
        /// </summary>
        /// <returns>Return the complete list of development enviroment.</returns>
        List<DevelopmentEnvironment> UDPSelectParametersTheKindsOfDevelopmentEnviroment();
    }
}