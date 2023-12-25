using NLog;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Json;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for (Log).
    /// </summary>
    public class ServiceLog : IServiceLog
    {
        private readonly IServiceJson _serviceJson;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public ServiceLog(IServiceJson serviceJson, IServiceFile serviceFile, IServiceDirectory serviceDirectory)
        {
            _serviceJson = serviceJson;
            _serviceFile = serviceFile;
            _serviceDirectory = serviceDirectory;
        }

        public void UDPLogDebug(string message) => _logger.Debug(message);

        public void UDPLogError(string message) => _logger.Error(message);

        public void UDPLogInformation(string message) => _logger.Info(message);

        public void UDPLogWarning(string message) => _logger.Warn(message);

        public void UDPRegisterLog(string message)
        {
            string json = string.Empty;
            string path = string.Empty;
            JsonConfiguration jsonConfiguration;

            path = _serviceDirectory.UDPGetRootPathFileInConfiguration($"{FileStandard.FILENAME_CONFIGURATION}{FileExtension.JSON}");
            json = _serviceFile.UDPReadAllText(path);
            jsonConfiguration = (JsonConfiguration)_serviceJson.UDPDesSerializerJsonToConfiguration(json);

            _serviceFile.UDPAppendAllText($"{jsonConfiguration.Path}{DirectoryStandard.LOG}{FileStandard.FILENAME_LOG}{FileExtension.TXT}",
                                            message);
        }
    }
}