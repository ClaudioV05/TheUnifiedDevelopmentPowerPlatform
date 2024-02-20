using Microsoft.AspNetCore.Mvc.ApplicationModels;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller;

namespace UnifiedDevelopmentPlatform.Presentation.Api.OpenApi
{
    public class OpenApiHideControllerConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (action is not null)
            {
                if (action.ActionName == ControllerActionName.MetadataAllTablesName)
                {
                    action.ApiExplorer.IsVisible = ControllerActionVisible.Visible;
                }

                if (action.ActionName == ControllerActionName.MetadataAllFieldsName)
                {
                    action.ApiExplorer.IsVisible = ControllerActionVisible.NotVisible;
                }
            }
        }
    }
}