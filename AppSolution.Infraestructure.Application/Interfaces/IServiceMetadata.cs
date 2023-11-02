using AppSolution.Infraestructure.Domain.Entities;

namespace AppSolution.Application.Interfaces
{
    public interface IServiceMetadata
    {
        List<string> MetadataAllTablesName(Metadata? metadata);
        List<string> MetadataTableAndAllFields(Metadata? metadata);
    }
}