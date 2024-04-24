using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters
{
    internal sealed class FilterActionContextControllerInformation : IAsyncActionFilter
    {
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// Filter action context controller information.
        /// </summary>
        /// <param name="serviceValidation"></param>
        /// <param name="serviceFuncString"></param>
        public FilterActionContextControllerInformation(IServiceValidation serviceValidation, 
                                                        IServiceFuncString serviceFuncString)
        {
            _serviceValidation = serviceValidation;
            _serviceFuncString = serviceFuncString;
        }

        /// <summary>
        /// On Action Execution Async.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = _serviceFuncString.Empty;

            try
            {
                if (!_serviceValidation.UDPPlatformWindowsIsOk(ref message))
                {
                    HasMessage(context, message);
                    return;
                }
            }
            catch (Exception)
            {
                throw new Exception(_serviceFuncString.UDPUpper(TextInformations.TheGlobalErrorMessage));
            }

            await next();
        }

        /// <summary>
        /// Has Message.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        private static void HasMessage(ActionExecutingContext context, string message)
        {
            context.Result = new BadRequestObjectResult(new ErrorDetails() { StatusCode = 1, Message = message });
        }
    }
}