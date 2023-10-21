using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSolution.Presentation.Api.Filters
{
    public class ValidateEntityFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var aux = string.Empty;
            if (context.ActionArguments.ContainsKey("ScriptMetadata"))
            {
                aux = (string)context.ActionArguments["ScriptMetadata"];
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}