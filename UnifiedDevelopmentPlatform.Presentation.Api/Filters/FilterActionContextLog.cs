using UnifiedDevelopmentPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    public class FilterActionContextLog : IAsyncActionFilter
    {
        private readonly IServiceLog _serviceLog;

        public FilterActionContextLog(IServiceLog serviceLog)
        {
            _serviceLog = serviceLog;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _serviceLog.UDPLogInformation("### -> OnActionExecuted");
            _serviceLog.UDPLogInformation("###################################################");
            _serviceLog.UDPLogInformation($"{DateTime.Now.ToLongTimeString()}");
            _serviceLog.UDPLogInformation("###################################################");

            await next();

            _serviceLog.UDPLogInformation("### -> OnActionExecuting");
            _serviceLog.UDPLogInformation("###################################################");
            _serviceLog.UDPLogInformation($"{DateTime.Now.ToLongTimeString()}");
            _serviceLog.UDPLogInformation($"ModelState : {context.ModelState.IsValid}");
            _serviceLog.UDPLogInformation("###################################################");
        }
    }
}