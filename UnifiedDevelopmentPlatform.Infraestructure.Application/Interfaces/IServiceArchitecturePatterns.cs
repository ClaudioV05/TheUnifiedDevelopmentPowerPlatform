using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service architecture patterns.
    /// </summary>
    public interface IServiceArchitecturePatterns
    {
        /// <summary>
        /// Select parameters the kinds of architecture patterns.
        /// </summary>
        /// <param name=""></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return the complete list of the architecture patterns.</returns>
        List<ArchitecturePatterns> UDPSelectParametersTheKindsOfArchitecturePatterns();

        /// <summary>
        /// Save identifier to the architecture patterns from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPSaveIdentifierToTheArchitecturePatternsFromMetadata(MetadataOwner metadata);
    }
}