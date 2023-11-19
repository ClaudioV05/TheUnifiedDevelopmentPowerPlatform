using AppSolution.Application.Interfaces;
using AppSolution.Infraestructure.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSolution.Presentation.Api.Filters
{
    public class FilterActionContextTables<T> : IAsyncActionFilter where T : class, IEntity
    {
        private readonly IServiceValidation _serviceValidation;

        public FilterActionContextTables(IServiceValidation serviceValidation)
        {
            _serviceValidation = serviceValidation;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult("É obrigatório informar o JSON para gerar o app.");
            }

            if (!_serviceValidation.ScriptMetadataIsOk(context))
            {
                context.Result = new BadRequestObjectResult("É obrigatório informar o Metada para gerar o app.");
            }

            if (!_serviceValidation.DevelopmentEnvironmentIsOk(context))
            {
                context.Result = new BadRequestObjectResult("É obrigatório informar o Development Environment para gerar o app.");
            }

            if (!_serviceValidation.DatabasesIsOk(context))
            {
                context.Result = new BadRequestObjectResult("É obrigatório informar o Databases para gerar o app.");
            }

            if (!_serviceValidation.FormIsOk(context))
            {
                context.Result = new BadRequestObjectResult("É obrigatório informar o Forms para gerar o app.");
            }

            await next();
        }
    }
}