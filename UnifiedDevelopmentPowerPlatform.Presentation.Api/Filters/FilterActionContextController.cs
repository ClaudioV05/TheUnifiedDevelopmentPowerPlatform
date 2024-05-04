using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters;

internal sealed class FilterActionContextController : IAsyncActionFilter
{
    private readonly IServiceLog _serviceLog;
    private readonly IServiceMessage _serviceMessage;
    private readonly IServiceDirectory _serviceDirectory;
    private readonly IServiceValidation _serviceValidation;
    private readonly IServiceFuncString _serviceFuncString;

    /// <summary>
    /// Filter action context controller.
    /// </summary>
    /// <param name="serviceLog"></param>
    /// <param name="serviceMessage"></param>
    /// <param name="serviceDirectory"></param>
    /// <param name="serviceValidation"></param>
    /// <param name="serviceFuncString"></param>
    public FilterActionContextController(IServiceLog serviceLog,
                                         IServiceMessage serviceMessage,
                                         IServiceDirectory serviceDirectory,
                                         IServiceValidation serviceValidation,
                                         IServiceFuncString serviceFuncString)
    {
        _serviceLog = serviceLog;
        _serviceMessage = serviceMessage;
        _serviceDirectory = serviceDirectory;
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

        if (context is not null && _serviceFuncString.UDPPLower(context.RouteData.Values["action"] as string) == ControllerActionArgumentsKey.Metadata)
        {
            try
            {
                if (!_serviceValidation.UDPPlatformWindowsIsOk(ref message))
                {
                    HasMessage(context, message);
                    return;
                }

                _serviceDirectory.UDPPCreateDirectoriesDefault();

                _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeGlobal.CallStartToTheCreationOfUnifiedDevelopmentPowerPlatform), _serviceFuncString.Empty);
                _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeValidation.ThePlatformWindowsIsNotOk), _serviceFuncString.Empty);
            }
            catch (Exception ex)
            {
                _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeGlobal.ErrorFilterActionContextController), ex.Message);
                throw new Exception(_serviceMessage.UDPPGetMessage(TypeGlobal.TheExceptionGlobalErrorMessage));
            }
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