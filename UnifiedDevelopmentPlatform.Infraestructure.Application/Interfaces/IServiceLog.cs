using NLog;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceLog
    {
        void UDPLogDebug(string message);

        void UDPLogError(string message);

        void UDPLogInformation(string message);

        void UDPLogWarning(string message);
    }
}