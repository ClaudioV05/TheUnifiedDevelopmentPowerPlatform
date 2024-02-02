using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service development environment.
    /// </summary>
    public interface IServiceDevelopmentEnvironment
    {
        /// <summary>
        /// Return the full list of all development environment.
        /// </summary>
        /// <returns>List of development environment</returns>
        List<DevelopmentEnvironment> UDPObtainTheListOfDevelopmentEnviroment();
    }
}