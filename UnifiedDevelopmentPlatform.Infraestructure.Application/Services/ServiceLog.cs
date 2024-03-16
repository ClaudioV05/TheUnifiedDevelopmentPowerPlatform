using NLog;
using System.Diagnostics;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Log;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.MetaCharacter;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Log.
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
        /// The constructor of Service Log.
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

        public void UDPLogReport(string message, string additionalMessage)
        {
            string data = _serviceFuncStrings.Empty;
            string newLine = _serviceFuncStrings.Empty;
            string directoryConfiguration = _serviceFuncStrings.Empty;
            StackFrame stack = new StackFrame(1, true);

            directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);

            if (!_serviceFuncStrings.UDPNullOrEmpty(directoryConfiguration) && _serviceDirectory.UDPDirectoryExists(directoryConfiguration))
            {
                if (!_serviceFuncStrings.UDPStringStarts(message, MessageText.TheInitialMessage))
                {
                    newLine = _servicePlataform.UDPEnvironmentAddNewLine();
                }

                if (stack is not null)
                {
                    data = $"{newLine}{LogConfiguration.Identifier}{_serviceGuid.UDPGenerateTheNewGuidObject()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.Datetime}{_serviceDate.UDPGetDateTimeNowFormat()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.FileName}{MetaCharacterSymbols.WhiteSpace}{_serviceFile.UDPGetFileName(stack.GetFileName() ?? _serviceFuncStrings.Empty)}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.MethodName}{MetaCharacterSymbols.WhiteSpace}{stack.GetMethod()?.Name}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.LineNumber}{MetaCharacterSymbols.WhiteSpace}{stack.GetFileLineNumber()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.LineColumn}{MetaCharacterSymbols.WhiteSpace}{stack.GetFileColumnNumber()}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.Message}{MetaCharacterSymbols.WhiteSpace}{_serviceFuncStrings.UDPUpper(message)}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{LogConfiguration.AdditionalMessage}{MetaCharacterSymbols.WhiteSpace}{_serviceFuncStrings.UDPUpper(additionalMessage)}{_servicePlataform.UDPEnvironmentAddNewLine()}" +
                           $"{_servicePlataform.UDPEnvironmentAddNewLine()}";

                    this.UDPLogInformation(data);

                    _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.Log}{FileExtension.Txt}", data);
                }
            }
        }
    }
}