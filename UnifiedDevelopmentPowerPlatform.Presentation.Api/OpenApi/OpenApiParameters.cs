using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.OpenApi;

public class OpenApiParameters : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation is not null || context is not null || context?.ApiDescription?.ParameterDescriptions is not null)
        {
            var actionExecuted = context?.ApiDescription?.RelativePath?.ToLowerInvariant();

            if (actionExecuted.Equals(ControllerRouterUnifiedDevelopmentPowerPlatform.RouterMetadata.ToLowerInvariant().Replace("/", string.Empty)))
            {
                if (operation?.Parameters is null)
                {
                    operation.Parameters = new List<OpenApiParameter>();
                }
                else if (operation?.Parameters is not null)
                {
                    operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Deprecated = false, AllowEmptyValue = false, Name = "Architecture", Schema = new OpenApiSchema { Type = "int" } });
                    operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Deprecated = false, AllowEmptyValue = false, Name = "DatabaseSchema", Schema = new OpenApiSchema { Type = "String" } });
                    operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Deprecated = false, AllowEmptyValue = false, Name = "IdDevelopmentEnvironment", Schema = new OpenApiSchema { Type = "int" } });
                    operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Deprecated = false, AllowEmptyValue = false, Name = "IdDatabases", Schema = new OpenApiSchema { Type = "int" } });
                    operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Deprecated = false, AllowEmptyValue = false, Name = "IdDatabasesEngine", Schema = new OpenApiSchema { Type = "int" } });
                    operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Deprecated = false, AllowEmptyValue = false, Name = "IdForms", Schema = new OpenApiSchema { Type = "int" } });
                }
            }
        }
    }
}