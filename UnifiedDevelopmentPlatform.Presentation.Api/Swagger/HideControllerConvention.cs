using Microsoft.AspNetCore.Mvc.ApplicationModels;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Swagger
{
    public class HideControllerConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
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