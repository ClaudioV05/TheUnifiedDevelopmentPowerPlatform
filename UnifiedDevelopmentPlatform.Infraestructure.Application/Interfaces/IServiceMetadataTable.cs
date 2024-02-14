using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Metadata Tables.
    /// </summary>
    public interface IServiceMetadataTable
    {
        /// <summary>
        /// Return List with tables name of metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>List with names of table.</returns>
        List<string> UDPListWithTablesNameOfMetadata(MetadataOwner metadata);

        /// <summary>
        /// Save database schema from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        void UDPSaveDatabaseSchemaFromMetadata(MetadataOwner metadata);
    }
}