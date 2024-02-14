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
        /// Return the full list of all databases.
        /// </summary>
        /// <returns>List of databases</returns>
        List<Databases> UDPObtainTheListOfDatabases();

        /// <summary>
        /// Return the full list of all forms.
        /// </summary>
        /// <returns>List of forms</returns>
        List<Forms> UDPObtainTheListOfForms();

        /// <summary>
        /// Return the full list of all development environment.
        /// </summary>
        /// <returns>List of development environment</returns>
        List<DevelopmentEnvironment> UDPObtainTheListOfDevelopmentEnviroment();

        /// <summary>
        /// Return the full list of all databases engine.
        /// </summary>
        /// <returns>List of databases engine</returns>
        List<DatabasesEngine> UDPObtainTheListOfDatabasesEngine();

        /// <summary>
        /// Return the full list of all architectures.
        /// </summary>
        /// <returns>List of architecture</returns>
        List<Architectures> UDPObtainTheListOfArchitectures();

        /// <summary>
        /// Return the information about Unified development platform.
        /// </summary>
        /// <returns>Information about Unified development platform.</returns>
        UnifiedDevelopmentPlatformInformation UDPObtainInformationUnifiedDevelopmentPlatform();
    }
}