using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters;

/// <summary>
/// Filter action context to metadata.
/// </summary>
internal sealed class FilterActionContextMetadata<T> : IAsyncActionFilter where T : class, IEntity
{
    private readonly IServiceLog _serviceLog;
    private readonly IServiceMessage _serviceMessage;
    private readonly IServiceDirectory _serviceDirectory;
    private readonly IServiceValidation _serviceValidation;
    private readonly IServiceFuncString _serviceFuncString;
    private readonly IServiceArchitecturePatterns _serviceArchitecturePatterns;

    /// <summary>
    /// Filter action context to metadata.
    /// </summary>
    /// <param name="serviceLog"></param>
    /// <param name="serviceMessage"></param>
    /// <param name="serviceDirectory"></param>
    /// <param name="serviceValidation"></param>
    /// <param name="serviceFuncString"></param>
    /// <param name="serviceArchitecturePatterns"></param>
    public FilterActionContextMetadata(IServiceLog serviceLog,
                                       IServiceMessage serviceMessage,
                                       IServiceDirectory serviceDirectory,
                                       IServiceValidation serviceValidation,
                                       IServiceFuncString serviceFuncString,
                                       IServiceArchitecturePatterns serviceArchitecturePatterns)
    {
        _serviceLog = serviceLog;
        _serviceMessage = serviceMessage;
        _serviceDirectory = serviceDirectory;
        _serviceValidation = serviceValidation;
        _serviceFuncString = serviceFuncString;
        _serviceArchitecturePatterns = serviceArchitecturePatterns;
    }

    /// <summary>
    /// On Action Execution Async.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string message = _serviceFuncString.Empty;

        try
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeGlobal.CallStartToTheFilterActionContextMetadata), _serviceFuncString.Empty);

            if (!_serviceValidation.UDPPModelStateIsOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPDatabaseSchemaIsOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPMetadataIsBase64Ok(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPDevelopmentEnvironmentIsOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPDatabasesIsOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPDatabasesImplementedIsOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPDatabasesEngineIsOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPFormsViewIsOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPArchitectureOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeGlobal.SuccessToTheFilterActionContextMetadata), _serviceFuncString.Empty);
        }
        catch (Exception ex)
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeGlobal.ErrorFilterActionContextMetadata), ex.Message);
            throw new Exception(_serviceMessage.UDPPGetMessage(TypeGlobal.TheExceptionGlobalErrorMessage));
        }

        await next();

        try
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDirectory.CallStartToTheCreateDirectoryProjectOfSolution), _serviceFuncString.Empty);
            _serviceDirectory.UDPPCreateDirectoriesFromArchitecture(_serviceArchitecturePatterns.UDPToReadIdentifierToTheArchitecturePatternsFromMetadata());
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDirectory.SuccessToTheCreateDirectoryProjectOfSolution), _serviceFuncString.Empty);
        }
        catch (Exception ex)
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDirectory.ErrorCreateAllDirectory), ex.Message);
            throw new Exception(_serviceMessage.UDPPGetMessage(TypeGlobal.TheExceptionGlobalErrorMessage));
        }
    }

    /// <summary>
    /// Has Message.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    private static void HasMessage(ActionExecutingContext context, string message)
    {
        context.Result = new BadRequestObjectResult(new ErrorDetails()
        {
            StatusCode = 1,
            Message = message
        });
    }
}