using AppSolution.Infraestructure.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection.Metadata;

namespace AppSolution.Presentation.Api.Filters
{
    public class AppSolutionActionFilter : IActionFilter
    {
        private readonly ILogger<AppSolutionActionFilter> _logger;

        public AppSolutionActionFilter(ILogger<AppSolutionActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            _logger.LogInformation("### Executando -> OnActionExecuted");
            _logger.LogInformation("###################################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation("###################################################");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something before the action executes.
            _logger.LogInformation("### Executando -> OnActionExecuting");
            _logger.LogInformation("###################################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState : {context.ModelState.IsValid}");
            _logger.LogInformation("###################################################");
        }
    }
}