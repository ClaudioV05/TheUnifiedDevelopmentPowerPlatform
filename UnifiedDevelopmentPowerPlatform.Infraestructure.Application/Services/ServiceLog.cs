using NLog;
using System.Diagnostics;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Logging;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

namespace UnifiedDevelopmentPowerPlatform.Application.Services
{
    /// <summary>
    /// Service log.
    /// </summary>
    public class ServiceLog : IServiceLog
    {
        private readonly IServiceFile _serviceFile;
        private readonly IServiceGuid _serviceGuid;
        private readonly IServiceDate _serviceDate;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServicePlataform _servicePlataform;
        private readonly IServiceFuncString _serviceFuncStrings;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The constructor of service Log.
        /// </summary>
        /// <param name="serviceFile"></param>
        /// <param name="serviceGuid"></param>
        /// <param name="serviceDate"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="servicePlataform"></param>
        /// <param name="serviceFuncStrings"></param>
        public ServiceLog(IServiceFile serviceFile,
                          IServiceGuid serviceGuid,
                          IServiceDate serviceDate,
                          IServiceDirectory serviceDirectory,
                          IServicePlataform servicePlataform,
                          IServiceFuncString serviceFuncStrings)
        {
            _serviceFile = serviceFile;
            _serviceGuid = serviceGuid;
            _serviceDate = serviceDate;
            _serviceDirectory = serviceDirectory;
            _servicePlataform = servicePlataform;
            _serviceFuncStrings = serviceFuncStrings;
        }

        public void UDPLogDebug(string message) => _logger.Debug(message);

        public void UDPLogError(string message) => _logger.Error(message);

        public void UDPLogInformation(string message) => _logger.Info(message);

        public void UDPLogWarning(string message) => _logger.Warn(message);

        public void UDPRegisterLog(string message, string additionalMessage)
        {
            string data = _serviceFuncStrings.Empty;
            string newFirstLine = _serviceFuncStrings.Empty;
            string directoryConfiguration = _serviceFuncStrings.Empty;
            StackFrame stack = new StackFrame(1, true);

            directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);

            if (!_serviceFuncStrings.UDPNullOrEmpty(directoryConfiguration) && _serviceDirectory.UDPDirectoryExists(directoryConfiguration))
            {
                if (!_serviceFuncStrings.UDPStringStarts(message, TextGlobal.CallStartToTheCreationOfUnifiedDevelopmentPowerPlatform))
                {
                    newFirstLine = _servicePlataform.UDPEnvironmentAddNewLine();
                }

                if (stack is not null)
                {
                    data = $"{newFirstLine}{LogConfiguration.Identifier}{_serviceGuid.UDPGenerateTheNewUniversallyUniqueIdentifier()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.Datetime}{_serviceDate.UDPGetDateTimeNowFormat()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.FileName}{_serviceFile.UDPGetFileName(stack.GetFileName() ?? _serviceFuncStrings.Empty)}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.MethodName}{stack.GetMethod()?.Name}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.LineNumber}{stack.GetFileLineNumber()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.LineColumn}{stack.GetFileColumnNumber()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.Message}{_serviceFuncStrings.UDPUpper(message)}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.AdditionalMessage}{_serviceFuncStrings.UDPUpper(additionalMessage)}{_servicePlataform.UDPEnvironmentAddNewLine()}";

                    this.UDPLogInformation(data);

                    _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.Log}{FileExtension.Txt}", data);
                }
            }
        }
    }
}