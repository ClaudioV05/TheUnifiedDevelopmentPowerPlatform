using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentParameter;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Metadata.
    /// </summary>
    public interface IServiceMetadata
    {
        /// <summary>
        /// Receive and save all table(s) and field(s) of schema database.
        /// </summary>
        /// <returns>The list of tables with name(s) and field(s) of schema database.</returns>
        List<Tables> UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner metadata);

        /// <summary>
        /// Not implemented yet.
        /// </summary>
        /// <returns></returns>
        void UDPNotImplemented(MetadataOwner metadata);

        /// <summary>
        /// Select parameters the kinds of databases.
        /// </summary>
        /// <returns>Return the complete list of databases.</returns>
        List<Databases> UDPSelectParametersTheKindsOfDatabases();

        /// <summary>
        /// Select parameters the kinds of forms.
        /// </summary>
        /// <returns>Return the complete list of forms.</returns>
        List<FormsView> UDPSelectParametersTheKindsOfForms();

        /// <summary>
        /// Select parameters the kinds of development enviroment.
        /// </summary>
        /// <returns>Return the complete list of development enviroment.</returns>
        List<DevelopmentEnvironments> UDPSelectParametersTheKindsOfDevelopmentEnviroment();

        /// <summary>
        /// Select parameters the kinds of databases engine.
        /// </summary>
        /// <returns>Return the complete list of databases engine.</returns>
        List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine();

        /// <summary>
        /// Select parameters the kinds of architecture patterns.
        /// </summary>
        /// <returns>Return the complete list of architecture patterns.</returns>
        List<ArchitecturePatterns> UDPSelectParametersTheKindsOfArchitecturePatterns();

        /// <summary>
        /// Return the parameters about Unified development platform.
        /// </summary>
        /// <returns>Information about Unified development platform.</returns>
        UnifiedDevelopmentParameters UDPSelectParametersInformationUnifiedDevelopmentPlatform();
    }
}