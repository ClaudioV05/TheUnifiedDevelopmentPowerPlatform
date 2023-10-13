using AppSolution.Infraestructure.Domain.Entities;

namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IGenerateTablesName
    {
        List<string> TablesName(GenerateClass? generateClass);
    }
}