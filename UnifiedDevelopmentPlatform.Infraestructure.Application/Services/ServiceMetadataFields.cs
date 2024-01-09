using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for Metadata Fields.
    /// </summary>
    public class ServiceMetadataFields : IServiceMetadataFields
    {
        /// <summary>
        /// The constructor of Service Metadata Fields.
        /// </summary>
        public ServiceMetadataFields()
        {

        }

        public List<string> UDPMetadataTableAndAllFields(MetadataOwner? metadata)
        {
            throw new NotImplementedException();
        }
    }
}