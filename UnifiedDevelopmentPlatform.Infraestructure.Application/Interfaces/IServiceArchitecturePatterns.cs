using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service architecture pattern
    /// </summary>
    public interface IServiceArchitecturePatterns
    {
        /// <summary>
        /// Select parameters the kinds of architecture patterns.
        /// </summary>
        /// <returns>Return the complete list of architecture patterns.</returns>
        List<ArchitecturePatterns> UDPSelectParametersTheKindsOfArchitecturePatterns();
    }
}