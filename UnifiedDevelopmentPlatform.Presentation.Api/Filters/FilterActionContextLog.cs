using UnifiedDevelopmentPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
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

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _serviceLog.UDPLogInformation("### -> OnActionExecuted");
            _serviceLog.UDPLogInformation("###################################################");
            _serviceLog.UDPLogInformation($"{_serviceDate.UDPGetDateTimeToLongTime()}");
            _serviceLog.UDPLogInformation("###################################################");

            await next();

            _serviceLog.UDPLogInformation("### -> OnActionExecuting");
            _serviceLog.UDPLogInformation("###################################################");
            _serviceLog.UDPLogInformation($"{_serviceDate.UDPGetDateTimeToLongTime()}");
            _serviceLog.UDPLogInformation($"ModelState : {context.ModelState.IsValid}");
            _serviceLog.UDPLogInformation("###################################################");
        }
    }
}