using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.OpenApi;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.OpenApi
{
    public class OpenApiDocumentation : IDocumentFilter
    {
        public void Apply(OpenApiDocument openApiDocumentationAttribute, DocumentFilterContext context)
        {
            if (openApiDocumentationAttribute is not null)
            {
                openApiDocumentationAttribute.Info = new OpenApiInfo
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
}