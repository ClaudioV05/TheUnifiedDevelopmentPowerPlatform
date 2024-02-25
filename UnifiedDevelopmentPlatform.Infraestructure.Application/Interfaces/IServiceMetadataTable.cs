using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Metadata Tables.
    /// </summary>
    public interface IServiceMetadataTable
    {
        /// <summary>
        /// Return a list with tables name of metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns>List with names of table.</returns>
        List<string> UDPListWithTablesNameOfMetadata(MetadataOwner metadata);

        /// <summary>
        /// Save the database schema from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        void UDPSaveDatabaseSchemaFromMetadata(MetadataOwner metadata);

        /// <summary>
        /// Open the database schema from metadata.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The string with database schema.</returns>
        string UDPOpenDatabaseSchemaFromMetadata();

        /// <summary>
        /// Get the table name.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The table name</returns>
        string UDPGetTableName(string text);
    }
}