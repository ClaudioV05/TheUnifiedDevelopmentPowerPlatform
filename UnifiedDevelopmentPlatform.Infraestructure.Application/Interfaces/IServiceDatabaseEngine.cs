using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service database engine.
    /// </summary>
    public interface IServiceDatabaseEngine
    {
        /// <summary>
        /// Return the full list of all databases engine.
        /// </summary>
        /// <returns>List of databases engine</returns>
        List<DatabasesEngine> UDPObtainTheListOfDatabasesEngine();
    }
}