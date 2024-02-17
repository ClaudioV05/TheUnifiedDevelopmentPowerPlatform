using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.UnifiedDevelopmentPlatformInformation;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Metadata.
    /// </summary>
    public interface IServiceMetadata
    {
        /// <summary>
        /// Receive and save all tables of schema database.
        /// </summary>
        /// <returns>Ther list with the name of table</returns>
        List<string> UDPReceiveAndSaveAllTableOfSchemaDatabase(MetadataOwner metadata);

        /// <summary>
        /// Receive and save all table and fields of schema database.
        /// </summary>
        /// <returns></returns>
        void UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner metadata);

        /// <summary>
        /// Select parameters the kinds of databases.
        /// </summary>
        /// <returns>Return the complete list of databases.</returns>
        List<Databases> UDPSelectParametersTheKindsOfDatabases();

        /// <summary>
        /// Select parameters the kinds of forms.
        /// </summary>
        /// <returns>Return the complete list of forms.</returns>
        List<Forms> UDPSelectParametersTheKindsOfForms();

        /// <summary>
        /// Select parameters the kinds of development enviroment.
        /// </summary>
        /// <returns>Return the complete list of development enviroment.</returns>
        List<DevelopmentEnvironment> UDPSelectParametersTheKindsOfDevelopmentEnviroment();

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
        UnifiedDevelopmentPlatformInformation UDPSelectParametersInformationUnifiedDevelopmentPlatform();
    }
}