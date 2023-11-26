using UnifiedDevelopmentPlatform.Application.Interfaces;
using NLog;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceLog : IServiceLog
    {
        private ILogger _logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => _logger.Debug(message);

        public void LogError(string message) => _logger.Error(message);

        public void LogInformation(string message) => _logger.Info(message);

        public void LogWarning(string message) => _logger.Warn(message);
    }
}