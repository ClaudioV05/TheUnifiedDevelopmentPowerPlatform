using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Log;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    public class FilterActionContextController : IAsyncActionFilter
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceValidation _serviceValidation;

        public FilterActionContextController(IServiceLog serviceLog, IServiceDirectory serviceDirectory, IServiceValidation serviceValidation)
        {
            _serviceLog = serviceLog;
            _serviceDirectory = serviceDirectory;
            _serviceValidation = serviceValidation;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = string.Empty;

            try
            {
                if (!_serviceValidation.UDPPlatformWindowsIsOk(ref message))
                {
                    HasMessage(context, message);
                    return;
                }

                _serviceDirectory.UPDCreateDirectoryStandardOfSolution();

                _serviceLog.UDPLogRegister(_serviceLog.UDPMensagem(LogEnumMensagem.Initial));
                _serviceLog.UDPLogRegister(_serviceLog.UDPMensagem(LogEnumMensagem.PlatformIsWindows));
            }
            catch (Exception)
            {
                _serviceLog.UDPLogRegister(_serviceLog.UDPMensagem(LogEnumMensagem.ErrorFilterActionContextController));
                throw new Exception(LogMensagem.ErrorFilterActionContextController);
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