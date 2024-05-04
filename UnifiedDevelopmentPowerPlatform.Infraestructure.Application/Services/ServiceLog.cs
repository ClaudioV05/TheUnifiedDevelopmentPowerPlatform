using NLog;
using System.Diagnostics;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Logging;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

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

    public void UDPPLogDebug(string message) => _logger.Debug(message);

    public void UDPPLogError(string message) => _logger.Error(message);

    public void UDPPLogInformation(string message) => _logger.Info(message);

    public void UDPPLogWarning(string message) => _logger.Warn(message);

    public void UDPPRegisterLog(string message, string additionalMessage)
    {
        string data = _serviceFuncStrings.Empty;
        string newFirstLine = _serviceFuncStrings.Empty;
        string directoryConfiguration = _serviceFuncStrings.Empty;
        StackFrame stack = new StackFrame(1, true);

        directoryConfiguration = _serviceDirectory.UDPPObtainDirectory(DirectoryRootType.Configuration);

        if (!_serviceFuncStrings.UDPPNullOrEmpty(directoryConfiguration) && _serviceDirectory.UDPPDirectoryExists(directoryConfiguration))
        {
            if (!_serviceFuncStrings.UDPPStringStarts(message, TextGlobal.CallStartToTheCreationOfUnifiedDevelopmentPowerPlatform))
            {
                newFirstLine = _servicePlataform.UDPPEnvironmentAddNewLine();
            }

            if (stack is not null)
            {
                data = $"{newFirstLine}{LogConfiguration.Identifier}{_serviceGuid.UDPPGenerateTheNewUniversallyUniqueIdentifier()}{_servicePlataform.UDPPEnvironmentAddNewLine()}" +
                       $"{LogConfiguration.Datetime}{_serviceDate.UDPPGetDateTimeNowFormat()}{_servicePlataform.UDPPEnvironmentAddNewLine()}" +
                       $"{LogConfiguration.FileName}{_serviceFile.UDPPGetFileName(stack.GetFileName() ?? _serviceFuncStrings.Empty)}{_servicePlataform.UDPPEnvironmentAddNewLine()}" +
                       $"{LogConfiguration.MethodName}{stack.GetMethod()?.Name}{_servicePlataform.UDPPEnvironmentAddNewLine()}" +
                       $"{LogConfiguration.LineNumber}{stack.GetFileLineNumber()}{_servicePlataform.UDPPEnvironmentAddNewLine()}" +
                       $"{LogConfiguration.LineColumn}{stack.GetFileColumnNumber()}{_servicePlataform.UDPPEnvironmentAddNewLine()}" +
                       $"{LogConfiguration.Message}{_serviceFuncStrings.UDPPUpper(message)}{_servicePlataform.UDPPEnvironmentAddNewLine()}" +
                       $"{LogConfiguration.AdditionalMessage}{_serviceFuncStrings.UDPPUpper(additionalMessage)}{_servicePlataform.UDPPEnvironmentAddNewLine()}";

                this.UDPPLogInformation(data);

                _serviceFile.UDPPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.Log}{FileExtension.Txt}", data);
            }
        }
    }
}