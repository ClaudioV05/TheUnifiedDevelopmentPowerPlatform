using UnifiedDevelopmentPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    public class FilterActionContextController : IAsyncActionFilter
    {
        private IServiceEnvironment _serviceEnvironment;

        public FilterActionContextController(IServiceEnvironment serviceEnvironment)
        {
            _serviceEnvironment = serviceEnvironment;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!_serviceEnvironment.PlatformIsWindows())
            {
                throw new Exception("This version of (Unified Development Platform) don't run in cross platform.");
            }


            await next();
        }
    }
}