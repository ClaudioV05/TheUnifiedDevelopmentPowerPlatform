using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPlatform.Application.Interfaces;
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
                _serviceLog.UDPLogInformation("teste1");
                _serviceLog.UDPRegisterLog("teste2");
            }
            catch (Exception)
            {
                throw new Exception("Erro ao criar diretório principal do Unified Development Platform - UDP.");
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