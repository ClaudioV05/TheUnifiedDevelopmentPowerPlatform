using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service database engine.
    /// </summary>
    public interface IServiceDatabaseEngine
    {
        /// <summary>
        /// Select parameters the kinds of databases engine.
        /// </summary>
        /// <returns>Return the complete list of databases engine.</returns>
        List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine();

        /// <summary>
        /// Save identifier to the databases engine from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        void UDPSaveIdentifierToTheDatabasesEngineFromMetadata(MetadataOwner metadata);
    }
}