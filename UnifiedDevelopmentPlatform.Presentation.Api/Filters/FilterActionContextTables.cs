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

            if (!_serviceValidation.ModelStateIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }

            if (!_serviceValidation.ScriptMetadataIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.MetadataIsBase64Ok(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.DevelopmentEnvironmentIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.DatabasesIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.DatabasesEngineIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }
            
            if (!_serviceValidation.FormIsOk(context, ref message))
            {
                HasMessage(context, message);
                return;
            }

            await next();

            try
            {
                _serviceDirectory.CreateAllDirectoryOfSolution();
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