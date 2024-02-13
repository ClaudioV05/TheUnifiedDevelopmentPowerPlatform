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
        private readonly IServiceFuncString _serviceFuncStrings;
        private readonly IServiceEnvironment _serviceEnvironment;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The constructor of Service Log.
        /// </summary>
        /// <param name="serviceFile"></param>
        /// <param name="serviceDate"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceEnvironment"></param>
        /// <param name="serviceFuncStrings"></param>
        public ServiceLog(IServiceFile serviceFile,
                          IServiceDate serviceDate,
                          IServiceDirectory serviceDirectory,
                          IServiceFuncString serviceFuncStrings,
                          IServiceEnvironment serviceEnvironment)
        {
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
            string directoryConfiguration = string.Empty;
            string caracter = string.Empty;

            directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);

            if (!_serviceFuncStrings.UDPStringStarts(message, MessageDescription.Initial))
            {
                caracter = _serviceEnvironment.UDPNewLine();
            }

            StackFrame stackFrame = new StackFrame(1, true);

            _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.Log}{FileExtension.Txt}",
                                          $"{caracter}{_serviceDate.UDPGetDateTimeNowFormat()} > File [{_serviceFile.UDPGetFileName(stackFrame.GetFileName())}] Line Number [{stackFrame.GetFileLineNumber()}] [{_serviceFuncStrings.UDPUpper(message)}]");
        }
    }
}