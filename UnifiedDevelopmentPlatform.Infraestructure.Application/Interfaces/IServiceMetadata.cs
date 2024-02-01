using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Metadata.
    /// </summary>
    public interface IServiceMetadata
    {
        /// <summary>
        /// Receive and save all tables of schema database.
        /// </summary>
        /// <returns>Ther list with the name of table</returns>
        List<string> UDPReceiveAndSaveAllTableOfSchemaDatabase(MetadataOwner? metadata);

        /// <summary>
        /// Receive and save all table and fields of schema database.
        /// </summary>
        /// <returns></returns>
        void UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner? metadata);

        /// <summary>
        /// Return the list with all of databases.
        /// </summary>
        /// <returns></returns>
        List<Databases> DatabasesList();

        /// <summary>
        /// Return the list with all of forms.
        /// </summary>
        /// <returns></returns>
        List<Forms> FormsList();
    }
}