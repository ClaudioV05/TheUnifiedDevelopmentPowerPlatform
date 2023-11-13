namespace AppSolution.Application.Interfaces
{
    public interface IServiceEnvironment
    {
        string? GetEnvVariable(string variable);
        string? GetEnvOSVersion();
        List<string> GetEnvListVariables();
        bool PlatformIsWindows();
    }
}