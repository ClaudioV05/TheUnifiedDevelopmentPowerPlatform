﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.OpenApi;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Swagger
{
    public class DocumentationAttribute : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Info = new OpenApiInfo
            {
                Version = OpenApiInformation.Version,
                Title = OpenApiInformation.Title,
                Description = OpenApiInformation.Description,
                TermsOfService = new Uri(OpenApiInformation.TermsOfService),
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = Infraestructure.Domain.Entities.OpenApi.OpenApiContact.Name,
                    Email = Infraestructure.Domain.Entities.OpenApi.OpenApiContact.Email,
                    Url = new Uri(Infraestructure.Domain.Entities.OpenApi.OpenApiContact.Url)
                },
                License = new Microsoft.OpenApi.Models.OpenApiLicense
                {
                    Name = Infraestructure.Domain.Entities.OpenApi.OpenApiLicense.Name,
                    Url = new Uri(Infraestructure.Domain.Entities.OpenApi.OpenApiLicense.Url)
                }
            };
        }
    }
}