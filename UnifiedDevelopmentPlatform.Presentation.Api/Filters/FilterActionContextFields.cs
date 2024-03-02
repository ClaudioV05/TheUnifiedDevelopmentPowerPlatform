using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    internal sealed class FilterActionContextFields<T> : IAsyncActionFilter where T : class, IEntity
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncString _serviceFuncStrings;

        /// <summary>
        /// Filter action context fields.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceValidation"></param>
        /// <param name="serviceFuncStrings"></param>
        public FilterActionContextFields(IServiceLog serviceLog,
                                         IServiceValidation serviceValidation,
                                         IServiceFuncString serviceFuncStrings)
        {
            _serviceLog = serviceLog;
            _serviceValidation = serviceValidation;
            _serviceFuncStrings = serviceFuncStrings;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = string.Empty;

            if (!_serviceValidation.UDPModelStateIsOk(context, ref message))
            {
                _serviceLog.UDPLogReport(message, _serviceFuncStrings.Empty);
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