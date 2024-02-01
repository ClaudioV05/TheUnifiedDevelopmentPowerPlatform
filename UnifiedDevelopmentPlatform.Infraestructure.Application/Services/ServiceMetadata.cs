using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Metadata.
    /// </summary>
    public class ServiceMetadata : IServiceMetadata
    {
        private readonly IServiceForm _serviceForm;
        private readonly IServiceDatabase _serviceDatabase;
        private readonly IServiceMetadataTable _serviceMetadataTables;

        /// <summary>
        /// The constructor of Service Metadata.
        /// </summary>
        /// <param name="serviceForm"></param>
        /// <param name="serviceDatabase"></param>
        /// <param name="serviceMetadataTables"></param>
        public ServiceMetadata(IServiceForm serviceForm, IServiceDatabase serviceDatabase, IServiceMetadataTable serviceMetadataTables)
        {
            _serviceForm = serviceForm;
            _serviceDatabase = serviceDatabase;
            _serviceMetadataTables = serviceMetadataTables;
        }

        public List<string> UDPReceiveAndSaveAllTableOfSchemaDatabase(MetadataOwner? metadata)
        {
            return _serviceMetadataTables.UDPMetadataAllTablesName(metadata);
        }

        public void UDPReceiveAndSaveAllTableAndFieldsOfSchemaDatabase(MetadataOwner? metadata)
        {
            throw new NotImplementedException();
        }

        public List<Databases> DatabasesList()
        {
            return _serviceDatabase.DatabasesList();
        }

        public List<Forms> FormsList()
        {
            return _serviceForm.FormsList();
        }
    }
}