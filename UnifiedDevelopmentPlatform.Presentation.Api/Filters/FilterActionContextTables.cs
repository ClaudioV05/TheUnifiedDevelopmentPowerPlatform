using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Filters
{
    public class FilterActionContextTables<T> : IAsyncActionFilter where T : class, IEntity
    {
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceValidation _serviceValidation;

        public FilterActionContextTables(IServiceDirectory serviceDirectory, IServiceValidation serviceValidation)
        {
            _serviceDirectory = serviceDirectory;
            _serviceValidation = serviceValidation;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string message = string.Empty;

            if (!_serviceValidation.UDPModelStateIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.UDPScriptMetadataIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.UDPMetadataIsBase64Ok(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.UDPDevelopmentEnvironmentIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.UDPDatabasesIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.UDPDatabasesEngineIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.UDPFormIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }

            await next();

            try
            {
                _serviceDirectory.UPDCreateAllDirectoryOfSolution();
            }
            catch (Exception)
            {
                message = "Erro ao criar diretório principal do Unified Development Platform - UDP.";
                HasMessage(context, message);
                return;
            }
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