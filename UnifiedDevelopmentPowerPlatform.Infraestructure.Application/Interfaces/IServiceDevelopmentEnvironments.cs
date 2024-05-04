using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service development environments.
/// </summary>
public interface IServiceDevelopmentEnvironments
{
    /// <summary>
    /// Select parameters the kinds of development enviroment.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the complete list of development enviroment.</returns>
    List<DevelopmentEnvironments> UDPPSelectParametersTheKindsOfDevelopmentEnviroment();

    /// <summary>
    /// Save identifier to the development enviroments from metadata.
    /// </summary>
    /// <param name="metadata"></param>
    /// /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPSaveIdentifierToTheDevelopmentEnviromentsFromMetadata(MetadataOwner metadata);

    /// <summary>
    /// Get the data type from table in script metadata.
    /// </summary>
    /// <param name="type"></param>
    /// /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <return>The string with the data type</return>
    string UDPPGetDataTypeFromTableInScriptMetadata(string type);
}