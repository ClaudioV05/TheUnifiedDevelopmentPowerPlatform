using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for Metadata Tables.
    /// </summary>
    public interface IServiceMetadataTables
    {
        /// <summary>
        /// Return all tables name.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>List with names of table.</returns>
        List<string> UDPMetadataAllTablesName(MetadataOwner? metadata);
    }
}