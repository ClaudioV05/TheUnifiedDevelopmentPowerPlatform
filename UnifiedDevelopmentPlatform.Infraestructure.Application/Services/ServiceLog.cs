using NLog;
using System.Diagnostics;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Log.
    /// </summary>
    public class ServiceLog : IServiceLog
    {
        private readonly IServiceFile _serviceFile;
        private readonly IServiceDate _serviceDate;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServicePlataform _servicePlataform;
        private readonly IServiceFuncString _serviceFuncStrings;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The constructor of Service Log.
        /// </summary>
        /// <param name="serviceFile"></param>
        /// <param name="serviceDate"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="servicePlataform"></param>
        /// <param name="serviceFuncStrings"></param>
        public ServiceLog(IServiceFile serviceFile,
                          IServiceDate serviceDate,
                          IServiceDirectory serviceDirectory,
                          IServicePlataform servicePlataform,
                          IServiceFuncString serviceFuncStrings)
        {
            _serviceFile = serviceFile;
            _serviceDate = serviceDate;
            _serviceDirectory = serviceDirectory;
            _servicePlataform = servicePlataform;
            _serviceFuncStrings = serviceFuncStrings;
        }

        public void UDPLogDebug(string message) => _logger.Debug(message);

        public void UDPLogError(string message) => _logger.Error(message);

        public void UDPLogInformation(string message) => _logger.Info(message);

        public void UDPLogWarning(string message) => _logger.Warn(message);

        public void UDPLogReport(string message)
        {
            string newLine = _serviceFuncStrings.Empty;
            string informations = _serviceFuncStrings.Empty;
            string directoryConfiguration = _serviceFuncStrings.Empty;

            directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);

            if (!_serviceFuncStrings.UDPStringStarts(message, MessageDescription.Initial))
            {
                newLine = _servicePlataform.UDPEnvironmentAddNewLine();
            }

            StackFrame stackFrame = new StackFrame(1, true);

            informations = $"{newLine}{_serviceDate.UDPGetDateTimeNowFormat()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"File: {_serviceFile.UDPGetFileName(stackFrame.GetFileName() ?? _serviceFuncStrings.Empty)}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"Line Number: {stackFrame.GetFileLineNumber()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"Message: {_serviceFuncStrings.UDPUpper(message)}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{_servicePlataform.UDPEnvironmentAddNewLine()}";

            this.UDPLogInformation(informations);

            _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.Log}{FileExtension.Txt}", informations);
        }
    }
}