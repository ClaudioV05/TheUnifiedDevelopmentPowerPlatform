using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for (Metadata).
    /// </summary>
    public interface IServiceMetadata
    {
        /// <summary>
        /// Return all tables name.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>List with names of table.</returns>
        List<string> UDPMetadataAllTablesName(Metadata? metadata);

        /// <summary>
        /// Return all tables name and all fields.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>List with names and fields of table.</returns>
        List<string> UDPMetadataTableAndAllFields(Metadata? metadata);
    }
}