using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service database.
    /// </summary>
    public interface IServiceDatabase
    {
        /// <summary>
        /// Return the full list of all databases.
        /// </summary>
        /// <returns>List of databases</returns>
        List<Databases> UDPObtainTheListOfDatabases();
    }
}