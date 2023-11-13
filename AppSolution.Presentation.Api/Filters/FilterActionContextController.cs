using AppSolution.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSolution.Presentation.Api.Filters
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
                throw new Exception("This version of appSolution don't run in cross platform.");

            await next();
        }
    }
}