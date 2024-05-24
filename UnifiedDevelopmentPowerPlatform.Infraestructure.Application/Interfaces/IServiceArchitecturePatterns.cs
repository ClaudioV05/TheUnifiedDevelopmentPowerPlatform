using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.ArchitecturePatterns;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service architecture patterns.
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public interface IServiceArchitecturePatterns
{
    /// <summary>
    /// To select parameters the kinds of architecture patterns.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the complete list of the architecture patterns.</returns>
    List<ArchitecturePatterns> UDPPToSelectParametersTheKindsOfArchitecturePatterns();

    /// <summary>
    /// To save identifier to the architecture patterns from metadata.
    /// </summary>
    /// <param name="metadata"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    void UDPPToSaveIdentifierToTheArchitecturePatternsFromMetadata(MetadataOwner metadata);

    /// <summary>
    /// To read identifier to the architecture patterns from metadata.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The enumerated of architecture patterns.</returns>
    EnumeratedArchitecturePatterns UDPPToReadIdentifierToTheArchitecturePatternsFromMetadata();

    /// <summary>
    /// Generates a back end solution.
    /// </summary>
    /// <param name="tables"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    void UDPPGeneratesBackendSolution(List<Tables> tables);

    /// <summary>
    /// Generates a back end solution.
    /// </summary>
    /// <param name="tables"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPGeneratesFrontendSolution(List<Tables> tables);
}