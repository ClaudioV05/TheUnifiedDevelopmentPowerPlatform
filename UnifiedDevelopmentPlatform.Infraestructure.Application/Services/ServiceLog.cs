using UnifiedDevelopmentPlatform.Application.Interfaces;
using NLog;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for (Log).
    /// </summary>
    public class ServiceLog : IServiceLog
    {
        private ILogger _logger = LogManager.GetCurrentClassLogger();

        public void UDPLogDebug(string message) => _logger.Debug(message);

        public void UDPLogError(string message) => _logger.Error(message);

        public void UDPLogInformation(string message) => _logger.Info(message);

        public void UDPLogWarning(string message) => _logger.Warn(message);
    }
}