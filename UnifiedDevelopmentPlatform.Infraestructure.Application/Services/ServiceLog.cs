using NLog;
using System.Diagnostics;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Json;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Log.
    /// </summary>
    public class ServiceLog : IServiceLog
    {
        private readonly IServiceJson _serviceJson;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceDate _serviceDate;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnvironment _serviceEnvironment;
        private readonly IServiceFuncString _serviceFuncStrings;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The constructor of Service Log.
        /// </summary>
        public ServiceLog(IServiceJson serviceJson, IServiceFile serviceFile, IServiceDate serviceDate, IServiceDirectory serviceDirectory, IServiceEnvironment serviceEnvironment, IServiceFuncString serviceFuncStrings)
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

        public void UDPLogReport(string? message)
        {
            string json = string.Empty;
            string path = string.Empty;
            string caracter = string.Empty;
            JsonConfiguration jsonConfiguration;

           /* path = _serviceDirectory.UDPGetRootPathFileInConfiguration($"{FileStandard.Configuration}{FileExtension.Json}");
            json = _serviceFile.UDPReadAllText(path);
            jsonConfiguration = (JsonConfiguration)_serviceJson.UDPDesSerializerJsonToConfiguration(json);

            if (!_serviceFuncStrings.UDPStringStarts(message, MessageDescription.Initial))
            {
                caracter = _serviceEnvironment.UDPNewLine();
            }

            StackFrame stackFrame = new StackFrame(1, true);

            _serviceFile.UDPAppendAllText($"{jsonConfiguration.Path}{DirectoryStandard.Log}{FileStandard.Log}{FileExtension.Txt}",
                                          $"{caracter}{_serviceDate.UDPGetDateTimeNowFormat()} > File [{_serviceFile.UDPGetFileName(stackFrame.GetFileName())}] Line Number [{stackFrame.GetFileLineNumber()}] [{_serviceFuncStrings.UDPUpper(message)}]");
           */
        }
    }
}