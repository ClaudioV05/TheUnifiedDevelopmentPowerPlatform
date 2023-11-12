using NLog;

namespace AppSolution.Application.Interfaces
{
    public interface IServiceLog
    {
        void LogDebug(string message);

        void LogError(string message);

        void LogInformation(string message);

        void LogWarning(string message);
    }
}