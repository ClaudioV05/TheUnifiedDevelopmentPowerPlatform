using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service service architecture
    /// </summary>
    public interface IServiceArchitecture
    {
        /// <summary>
        /// Select parameters the kinds of architectures.
        /// </summary>
        /// <returns>Return the complete list of architectures.</returns>
        List<Architectures> UDPSelectParametersTheKindsOfArchitectures();
    }
}