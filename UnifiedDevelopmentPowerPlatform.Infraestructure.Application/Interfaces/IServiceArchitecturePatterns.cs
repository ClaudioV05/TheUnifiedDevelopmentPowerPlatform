﻿using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.ArchitecturePatterns;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service architecture patterns.
/// </summary>
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
    List<ArchitecturePatterns> UDPToSelectParametersTheKindsOfArchitecturePatterns();

    /// <summary>
    /// To save identifier to the architecture patterns from metadata.
    /// </summary>
    /// <param name="metadata"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    void UDPToSaveIdentifierToTheArchitecturePatternsFromMetadata(MetadataOwner metadata);

    /// <summary>
    /// To read identifier to the architecture patterns from metadata.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The enumerated of architecture patterns.</returns>
    EnumeratedArchitecturePatterns UDPToReadIdentifierToTheArchitecturePatternsFromMetadata();
}