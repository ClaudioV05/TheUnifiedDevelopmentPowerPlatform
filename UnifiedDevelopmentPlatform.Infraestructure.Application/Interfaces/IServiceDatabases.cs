using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service databases.
    /// </summary>
    public interface IServiceDatabases
    {
        /// <summary>
        /// Select parameters the kinds of databases.
        /// </summary>
        /// <returns>Return the complete list of databases.</returns>
        List<Databases> UDPSelectParametersTheKindsOfDatabases();

        /// <summary>
        /// Save identifier to the databases from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        void UDPSaveIdentifierToTheDatabasesFromMetadata(MetadataOwner metadata);
    }
}