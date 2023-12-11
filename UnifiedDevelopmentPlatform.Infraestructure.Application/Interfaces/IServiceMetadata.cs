using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceMetadata
    {
        List<string> UDPMetadataAllTablesName(Metadata? metadata);
        List<string> UDPMetadataTableAndAllFields(Metadata? metadata);
    }
}