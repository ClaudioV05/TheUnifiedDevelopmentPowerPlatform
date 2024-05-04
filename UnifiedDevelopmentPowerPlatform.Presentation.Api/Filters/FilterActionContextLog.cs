using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters;

internal sealed class FilterActionContextLog : IAsyncActionFilter
{
    private readonly IServiceLog _serviceLog;
    private readonly IServiceDate _serviceDate;

    /// <summary>
    /// Filter action context log.
    /// </summary>
    /// <param name="serviceLog"></param>
    /// <param name="serviceDate"></param>
    public FilterActionContextLog(IServiceLog serviceLog,
                                  IServiceDate serviceDate)
    {
        _serviceLog = serviceLog;
        _serviceDate = serviceDate;
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
        _serviceLog.UDPPLogInformation("### -> OnActionExecuted");
        _serviceLog.UDPPLogInformation("###################################################");
        _serviceLog.UDPPLogInformation($"{_serviceDate.UDPPGetDateTimeToLongTime()}");
        _serviceLog.UDPPLogInformation("###################################################");

        await next();

        _serviceLog.UDPPLogInformation("### -> OnActionExecuting");
        _serviceLog.UDPPLogInformation("###################################################");
        _serviceLog.UDPPLogInformation($"{_serviceDate.UDPPGetDateTimeToLongTime()}");
        _serviceLog.UDPPLogInformation($"ModelState : {context.ModelState.IsValid}");
        _serviceLog.UDPPLogInformation("###################################################");
    }
}