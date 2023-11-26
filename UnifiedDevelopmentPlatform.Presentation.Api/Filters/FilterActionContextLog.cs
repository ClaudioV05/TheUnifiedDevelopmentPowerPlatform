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
            _serviceLog.LogInformation("### -> OnActionExecuted");
            _serviceLog.LogInformation("###################################################");
            _serviceLog.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _serviceLog.LogInformation("###################################################");

            await next();

            _serviceLog.LogInformation("### -> OnActionExecuting");
            _serviceLog.LogInformation("###################################################");
            _serviceLog.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _serviceLog.LogInformation($"ModelState : {context.ModelState.IsValid}");
            _serviceLog.LogInformation("###################################################");
        }
    }
}