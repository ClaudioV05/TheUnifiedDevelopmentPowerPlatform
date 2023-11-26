namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceEnvironment
    {
        string? GetEnvVariable(string variable);

        List<string> GetEnvListVariables();

        bool PlatformIsWindows();
    }
}