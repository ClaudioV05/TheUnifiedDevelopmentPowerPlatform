using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service database.
    /// </summary>
    public interface IServiceDatabase
    {
        /// <summary>
        /// Select parameters the kinds of databases.
        /// </summary>
        /// <returns>Return the complete list of databases.</returns>
        List<Databases> UDPSelectParametersTheKindsOfDatabases();
    }
}