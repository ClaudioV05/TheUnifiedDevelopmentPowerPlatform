using AppSolution.Infraestructure.Domain.Entities;

namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IServicesMetadata
    {
        List<string> MetadataAllTablesName(Metadata? metadata);
    }
}