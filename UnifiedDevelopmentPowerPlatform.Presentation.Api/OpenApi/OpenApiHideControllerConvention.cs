using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.OpenApi;

public class OpenApiHideControllerConvention : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        if (action is not null)
        {
            action.ApiExplorer.IsVisible = true;
        }
    }
}