using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.ArchitecturePatterns;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service directory.
/// </summary>
public interface IServiceDirectory
{
    /// <summary>
    /// Create the directories default of solution UDPP.
    /// </summary>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    void UDPPCreateDirectoriesDefault();

    /// <summary>
    /// Create the directories from architecture.
    /// </summary>
    /// <param name="enumeratedArchitecturePatterns"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    void UDPPCreateDirectoriesFromArchitecture(EnumeratedArchitecturePatterns enumeratedArchitecturePatterns);

    /// <summary>
    /// Verify if directory exists.
    /// </summary>
    /// <param name="absolutePath"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPDirectoryExists(string absolutePath);

    /// <summary>
    /// Obtain directory root.
    /// </summary>
    /// <param name="directoryRootType"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPObtainDirectory(DirectoryRootType directoryRootType);

    /// <summary>
    /// Get metrics of the total size of directory by parallel processing.
    /// </summary>
    /// <param name="directory"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the total size of directoy at the moment of call.</returns>
    long UDPPGetMetricsOfTheTotalSizeOfDirectory(DirectoryInfo directory);
}