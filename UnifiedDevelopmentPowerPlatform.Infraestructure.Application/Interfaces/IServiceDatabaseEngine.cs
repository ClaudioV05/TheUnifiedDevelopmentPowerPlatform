using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service database engine.
/// </summary>
public interface IServiceDatabaseEngine
{
    /// <summary>
    /// Select parameters the kinds of the databases engine.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the complete list of databases engine.</returns>
    List<DatabasesEngine> UDPPSelectParametersTheKindsOfDatabasesEngine();

    /// <summary>
    /// Save identifier to the databases engine from metadata.
    /// </summary>
    /// <param name="metadata"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPSaveIdentifierToTheDatabasesEngineFromMetadata(MetadataOwner metadata);
}