using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentParameter;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service metadata.
/// </summary>
public interface IServiceMetadata
{
    /// <summary>
    /// Receive and save all table(s) and field(s) of schema database.
    /// </summary>
    /// <param name="metadata"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The list of tables with name(s) and field(s) of schema database.</returns>
    List<Tables> UDPReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase(MetadataOwner metadata);

    /// <summary>
    /// Receive the table(s) data with their field(s) that will generate the solution UDPP.
    /// </summary>
    /// <param name="metadata"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The solution in the format specified.</returns>
    MetadataOwner UDPReceiveTheTablesdataAndGenerateTheSolution(MetadataOwner metadata);

    /// <summary>
    /// Not implemented yet.
    /// </summary>
    /// <param name="metadata"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    void UDPNotImplemented(MetadataOwner metadata);

    /// <summary>
    /// Select parameters the kinds of databases.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the complete list of databases.</returns>
    List<Databases> UDPSelectParametersTheKindsOfDatabases();

    /// <summary>
    /// Select parameters the kinds of forms.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the complete list of forms.</returns>
    List<FormsView> UDPSelectParametersTheKindsOfForms();

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
    List<DevelopmentEnvironments> UDPSelectParametersTheKindsOfDevelopmentEnviroment();

    /// <summary>
    /// Select parameters the kinds of databases engine.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the complete list of databases engine.</returns>
    List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine();

    /// <summary>
    /// Select parameters the kinds of architecture patterns.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the complete list of architecture patterns.</returns>
    List<ArchitecturePatterns> UDPSelectParametersTheKindsOfArchitecturePatterns();

    /// <summary>
    /// Return the parameters about Unified development platform.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Information about Unified development platform.</returns>
    UnifiedDevelopmentParameters UDPSelectParametersInformationUnifiedDevelopmentPowerPlatform();
}