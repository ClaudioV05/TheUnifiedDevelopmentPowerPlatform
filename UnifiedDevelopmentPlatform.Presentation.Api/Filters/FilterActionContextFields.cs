using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    internal sealed class FilterActionContextFields<T> : IAsyncActionFilter where T : class, IEntity
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// Filter action context fields.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceValidation"></param>
        /// <param name="serviceFuncString"></param>
        public FilterActionContextFields(IServiceLog serviceLog,
                                         IServiceMessage serviceMessage,
                                         IServiceValidation serviceValidation,
                                         IServiceFuncString serviceFuncString)
        {
            _serviceLog = serviceLog;
            _serviceMessage = serviceMessage;
            _serviceValidation = serviceValidation;
            _serviceFuncString = serviceFuncString;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = _serviceFuncString.Empty;

            if (!_serviceValidation.UDPModelStateIsOk(context, ref message))
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.ErrorFilterActionContextFields), message);
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