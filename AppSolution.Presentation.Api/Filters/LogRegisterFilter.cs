using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSolution.Presentation.Api.Filters
{
    public class LogRegisterFilter : IActionFilter
    {
        private readonly ILogger<LogRegisterFilter> _logger;

        public LogRegisterFilter(ILogger<LogRegisterFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes.
            _logger.LogInformation("### -> OnActionExecuted");
            _logger.LogInformation("###################################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation("###################################################");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes.
            _logger.LogInformation("### -> OnActionExecuting");
            _logger.LogInformation("###################################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState : {context.ModelState.IsValid}");
            _logger.LogInformation("###################################################");
        }
    }
}