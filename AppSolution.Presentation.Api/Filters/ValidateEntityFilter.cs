using AppSolution.Infraestructure.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSolution.Presentation.Api.Filters
{
    public class ValidateEntityFilter<T> : IActionFilter where T : class, IEntity
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("metadata"))
            {
                var aux = (string)context.ActionArguments["ScriptMetadata"];
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad ScriptMetadata parameter");
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}