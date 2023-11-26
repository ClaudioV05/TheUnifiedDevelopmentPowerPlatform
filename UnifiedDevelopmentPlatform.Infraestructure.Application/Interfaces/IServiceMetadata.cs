using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceMetadata
    {
        List<string> MetadataAllTablesName(Metadata? metadata);
        List<string> MetadataTableAndAllFields(Metadata? metadata);
    }
}