using AppSolution.Infraestructure.Domain.Entities;

namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IServicesGenerateTablesName
    {
        List<string> returnListTables(GenerateClass? generateClass);
    }
}