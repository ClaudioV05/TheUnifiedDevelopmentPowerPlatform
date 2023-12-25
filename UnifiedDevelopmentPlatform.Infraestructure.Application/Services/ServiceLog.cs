using NLog;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Json;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Log;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for (Log).
    /// </summary>
    public class ServiceLog : IServiceLog
    {
        private readonly IServiceJson _serviceJson;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceDate _serviceDate;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnvironment _serviceEnvironment;
        private readonly IServiceFuncStrings _serviceFuncStrings;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public ServiceLog(IServiceJson serviceJson, IServiceFile serviceFile, IServiceDate serviceDate, IServiceDirectory serviceDirectory, IServiceEnvironment serviceEnvironment, IServiceFuncStrings serviceFuncStrings)
        {
            _serviceJson = serviceJson;
            _serviceFile = serviceFile;
            _serviceDate = serviceDate;
            _serviceDirectory = serviceDirectory;
            _serviceEnvironment = serviceEnvironment;
            _serviceFuncStrings = serviceFuncStrings;
        }

        public void UDPLogDebug(string message) => _logger.Debug(message);

        public void UDPLogError(string message) => _logger.Error(message);

        public void UDPLogInformation(string message) => _logger.Info(message);

        public void UDPLogWarning(string message) => _logger.Warn(message);

        public void UDPLogRegister(string? message)
        {
            string json = string.Empty;
            string path = string.Empty;
            string caracter = string.Empty;
            JsonConfiguration jsonConfiguration;

            path = _serviceDirectory.UDPGetRootPathFileInConfiguration($"{FileStandard.FILENAME_CONFIGURATION}{FileExtension.JSON}");
            json = _serviceFile.UDPReadAllText(path);
            jsonConfiguration = (JsonConfiguration)_serviceJson.UDPDesSerializerJsonToConfiguration(json);

            if (!_serviceFuncStrings.StringStarts(message, LogMensagem.Initial))
            {
                caracter = _serviceEnvironment.UDPNewLine();
            }

            _serviceFile.UDPAppendAllText($"{jsonConfiguration.Path}{DirectoryStandard.LOG}{FileStandard.FILENAME_LOG}{FileExtension.TXT}",
                                          $"{caracter}{_serviceDate.UDPGetDateTimeNowFormat()} - [{_serviceFuncStrings.Upper(message)}]");
        }

        public string? UDPMensagem(LogEnumMensagem logEnumMensagem)
        {
            return logEnumMensagem switch
            {
                LogEnumMensagem.Initial => LogMensagem.Initial,
                LogEnumMensagem.PlatformIsWindows => LogMensagem.PlatformIsWindows,
                _ => LogMensagem.NoMessage
            };
        }
    }
}