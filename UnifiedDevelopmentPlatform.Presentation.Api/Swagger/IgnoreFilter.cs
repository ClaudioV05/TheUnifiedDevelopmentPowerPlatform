using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.Json.Serialization;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Swagger
{
    public class IgnoreFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties.Count == 0)
            {
                return;
            }

            var properties = context.Type.GetProperties();

            var excludedList = properties
                .Where(element => element.GetCustomAttribute<SwaggerIgnoreAttribute>() is not null)
                .Select(element => element.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? element.Name);

            foreach (var excludedName in excludedList)
            {
                schema.Properties.Remove(excludedName);
            }
        }
    }
}