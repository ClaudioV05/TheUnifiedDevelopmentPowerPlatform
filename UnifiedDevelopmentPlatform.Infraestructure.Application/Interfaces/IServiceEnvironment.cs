namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceEnvironment
    {
        string? UPDGetEnvVariable(string variable);

        List<string> UPDGetEnvListVariables();

        bool UPDPlatformIsWindows();
    }
}