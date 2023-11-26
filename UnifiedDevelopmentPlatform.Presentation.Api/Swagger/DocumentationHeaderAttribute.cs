﻿using Microsoft.OpenApi.Models;
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

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ScriptMetadata",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String"
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "IdDevelopmentEnvironment",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "int"
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "IdDatabases",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "int"
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "IdDatabasesEngine",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "int"
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "IdForms",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "int"
                }
            });
        }
    }
}