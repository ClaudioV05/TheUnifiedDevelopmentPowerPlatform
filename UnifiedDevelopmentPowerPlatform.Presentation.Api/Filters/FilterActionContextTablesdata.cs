using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters;

/// <summary>
/// Filter action context to tables data.
/// </summary>
internal sealed class FilterActionContextTablesdata<T> : IAsyncActionFilter where T : class, IEntity
{
    private readonly IServiceLog _serviceLog;
    private readonly IServiceMessage _serviceMessage;
    private readonly IServiceValidation _serviceValidation;
    private readonly IServiceFuncString _serviceFuncString;

    /// <summary>
    /// Filter action context to tables data.
    /// </summary>
    /// <param name="serviceLog"></param>
    /// <param name="serviceMessage"></param>
    /// <param name="serviceValidation"></param>
    /// <param name="serviceFuncString"></param>
    public FilterActionContextTablesdata(IServiceLog serviceLog,
                                         IServiceMessage serviceMessage,
                                         IServiceValidation serviceValidation,
                                         IServiceFuncString serviceFuncString)
    {
        _serviceLog = serviceLog;
        _serviceMessage = serviceMessage;
        _serviceValidation = serviceValidation;
        _serviceFuncString = serviceFuncString;
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
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeGlobal.CallStartToTheFilterActionContextTablesdata), _serviceFuncString.Empty);

            if (!_serviceValidation.UDPPModelStateIsOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPTablesdataIsOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPTablesdataHasFieldsContent(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPDirectoriesOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPFilesOk(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPPFilesHasContent(context, ref message))
            {
                _serviceLog.UDPPRegisterLog(message, _serviceFuncString.Empty);
                HasMessage(context, message);
                return;
            }

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeGlobal.SuccessToTheFilterActionContextTablesdata), _serviceFuncString.Empty);
        }
        catch (Exception ex)
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeGlobal.ErrorFilterActionContextTablesdata), ex.Message);
            throw new Exception(_serviceMessage.UDPPGetMessage(TypeGlobal.TheExceptionGlobalErrorMessage));
        }

        await next();
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