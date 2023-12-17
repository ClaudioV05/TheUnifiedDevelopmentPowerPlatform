using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Swagger
{
    public class DocumentationHeaderAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Name = "ScriptMetadata", Schema = new OpenApiSchema { Type = "String" } });
            operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Name = "IdDevelopmentEnvironment", Schema = new OpenApiSchema { Type = "int" } });
            operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Name = "IdDatabases", Schema = new OpenApiSchema { Type = "int" } });
            operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Name = "IdDatabasesEngine", Schema = new OpenApiSchema { Type = "int" } });
            operation.Parameters.Add(new OpenApiParameter { In = ParameterLocation.Header, Required = false, Name = "IdForms", Schema = new OpenApiSchema { Type = "int" } });
        }
    }
}