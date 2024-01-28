using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Metadata Fields.
    /// </summary>
    public class ServiceMetadataField : IServiceMetadataField
    {
        /// <summary>
        /// The constructor of Service Metadata Fields.
        /// </summary>
        public ServiceMetadataField()
        {

        }

        public List<string> UDPMetadataTableAndAllFields(MetadataOwner? metadata)
        {
            throw new NotImplementedException();
        }
    }
}