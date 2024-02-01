using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service database.
    /// </summary>
    public interface IServiceDatabase
    {
        /// <summary>
        /// Return the list with all of databases.
        /// </summary>
        /// <returns></returns>
        List<Databases> DatabasesList();
    }
}