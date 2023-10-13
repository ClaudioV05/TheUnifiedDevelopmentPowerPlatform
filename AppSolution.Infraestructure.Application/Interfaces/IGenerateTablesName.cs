using AppSolution.Infraestructure.Domain.Entities;

namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IGenerateTablesName
    {
        IEnumerable<string> TablesName(GenerateClass? generateClass);
    }
}