using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    public class FilterActionContextController : IAsyncActionFilter
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncStrings _serviceFuncStrings;

        public FilterActionContextController(IServiceLog serviceLog, IServiceDirectory serviceDirectory, IServiceValidation serviceValidation, IServiceFuncStrings serviceFuncStrings)
        {
            _serviceLog = serviceLog;
            _serviceDirectory = serviceDirectory;
            _serviceValidation = serviceValidation;
            _serviceFuncStrings = serviceFuncStrings;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = _serviceFuncStrings.Empty;

            try
            {
                if (!_serviceValidation.UDPPlatformWindowsIsOk(ref message))
                {
                    _serviceLog.UDPLogRegister(message);
                    HasMessage(context, message);
                    return;
                }

                _serviceDirectory.UPDCreateDirectoryStandardOfSolution();

                _serviceLog.UDPLogRegister(_serviceLog.UDPMensagem(MessageEnumerated.Initial));
                _serviceLog.UDPLogRegister(_serviceLog.UDPMensagem(MessageEnumerated.PlatformIsWindowsOk));
            }
            catch (Exception)
            {
                _serviceLog.UDPLogRegister(_serviceLog.UDPMensagem(MessageEnumerated.ErrorFilterActionContextController));
                throw new Exception(MessageDescription.ErrorFilterActionContextController);
            }

            await next();
        }

        private static void HasMessage(ActionExecutingContext context, string message)
        {
            context.Result = new BadRequestObjectResult(new ErrorDetails()
            {
                StatusCode = 1,
                Message = message
            });
        }
    }
}