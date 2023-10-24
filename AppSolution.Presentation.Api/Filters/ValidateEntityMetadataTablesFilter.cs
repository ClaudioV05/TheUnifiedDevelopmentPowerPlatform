using AppSolution.Infraestructure.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSolution.Presentation.Api.Filters
{
    public class ValidateEntityMetadataTablesFilter<T> : IActionFilter where T : class, IEntity
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid is false)
                context.Result = new BadRequestObjectResult("é obrigatorio informar.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}