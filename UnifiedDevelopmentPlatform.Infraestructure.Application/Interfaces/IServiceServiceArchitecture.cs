using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service service architecture
    /// </summary>
    public interface IServiceArchitecture
    {
        /// <summary>
        /// Return the full list of all architectures.
        /// </summary>
        /// <returns>List of architectures</returns>
        List<Architectures> UDPObtainTheListOfArchitectures();
    }
}