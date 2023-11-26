using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;
using UnifiedDevelopmentPlatform.Presentation.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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
            string messageValidation = string.Empty;

            if (!context.ModelState.IsValid)
            {
                messageValidation = "É obrigatório informar o JSON para gerar o app.";
            }
            else if (!_serviceValidation.ScriptMetadataIsOk(context, ref message))
            {
                messageValidation = message;
            }
            else if (!_serviceValidation.MetadataIsBase64Ok(context, ref message))
            {
                messageValidation = message;
            }
            else if (!_serviceValidation.DevelopmentEnvironmentIsOk(context, ref message))
            {
                messageValidation = message;
            }
            else if (!_serviceValidation.DatabasesIsOk(context, ref message))
            {
                messageValidation = message;
            }
            else if (!_serviceValidation.DatabasesEngineIsOk(context, ref message))
            {
                messageValidation = message;
            }
            else if (!_serviceValidation.FormIsOk(context, ref message))
            {
                messageValidation = message;
            }

            if (!string.IsNullOrEmpty(messageValidation))
            {
                context.Result = new BadRequestObjectResult(new ErrorDetails()
                {
                    Message = messageValidation,
                    StatusCode = 1
                });

                return;
            }

            await next();

            if (_serviceDirectory.CreateAppDirectory())
            {
                _serviceDirectory.CreateConfigDirectory();
                var aux = _serviceDirectory.ReadAppDirectory();
            }
            else
            {
                context.Result = new BadRequestObjectResult(new ErrorDetails()
                {
                    Message = "Erro ao criar diretório principal do Unified Development Platform.",
                    StatusCode = 1
                });

                return;
            }
        }
    }
}
