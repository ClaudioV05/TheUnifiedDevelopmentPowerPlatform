namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IServiceEnvironment
    {
        string? GetEnvVariable(string variable);
        string? GetEnvOSVersion();
        List<string> GetEnvListVariables();
    }
}