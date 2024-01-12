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
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceValidation _serviceValidation;
        private readonly IServiceFuncStrings _serviceFuncStrings;

        public FilterActionContextController(IServiceLog serviceLog, IServiceMessage serviceMessage, IServiceDirectory serviceDirectory, IServiceValidation serviceValidation, IServiceFuncStrings serviceFuncStrings)
        {
            _serviceLog = serviceLog;
            _serviceMessage = serviceMessage;
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
                    _serviceLog.UDPLogReport(message);
                    HasMessage(context, message);
                    return;
                }

                _serviceDirectory.UPDBuildDirectoryStandardOfSolution();

                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageEnumerated.Initial));
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageEnumerated.PlatformIsWindowsOk));
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport($"{_serviceMessage.UDPMensagem(MessageEnumerated.ErrorFilterActionContextController)} {ex.Message}");
                throw new Exception(_serviceFuncStrings.UDPUpper(MessageDescription.ErrorFilterActionContextController));
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