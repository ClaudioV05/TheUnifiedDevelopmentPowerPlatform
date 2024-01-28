using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Metadata.
    /// </summary>
    public class ServiceMetadata : IServiceMetadata
    {
        private readonly IServiceMetadataTables _serviceMetadataTables;

        /// <summary>
        /// The constructor of Service Metadata.
        /// </summary>
        /// <param name="serviceMetadataTables"></param>
        public ServiceMetadata(IServiceMetadataTables serviceMetadataTables)
        {
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
    }
}