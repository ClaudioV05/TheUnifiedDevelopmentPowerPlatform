using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    public class FilterActionContextFields<T> : IAsyncActionFilter where T : class, IEntity
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceValidation _serviceValidation;

        public FilterActionContextFields(IServiceLog serviceLog, IServiceValidation serviceValidation)
        {
            _serviceLog = serviceLog;
            _serviceValidation = serviceValidation;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = string.Empty;

            if (!_serviceValidation.UDPModelStateIsOk(context, ref message))
            {
                _serviceLog.UDPLogReport(message);
                HasMessage(context, message);
                return;
            }

            await next();
        }

        private static void HasMessage(ActionExecutingContext context, string message)
        {
            context.Result = new BadRequestObjectResult(new ErrorDetails() { StatusCode = 1, Message = message });
        }
    }
}