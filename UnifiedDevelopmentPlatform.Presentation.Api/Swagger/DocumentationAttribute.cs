using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.OpenApi;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Swagger
{
    public class DocumentationAttribute : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Info = new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = Infraestructure.Domain.Entities.OpenApi.OpenApiInformation.VERSION,
                Title = Infraestructure.Domain.Entities.OpenApi.OpenApiInformation.TITLE,
                Description = Infraestructure.Domain.Entities.OpenApi.OpenApiInformation.DESCRIPTION,
                TermsOfService = new Uri(Infraestructure.Domain.Entities.OpenApi.OpenApiInformation.TERMSOFSERVICE),
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = Infraestructure.Domain.Entities.OpenApi.OpenApiContact.NAME,
                    Email = Infraestructure.Domain.Entities.OpenApi.OpenApiContact.EMAIL,
                    Url = new Uri(Infraestructure.Domain.Entities.OpenApi.OpenApiContact.URL)
                },
                License = new Microsoft.OpenApi.Models.OpenApiLicense
                {
                    Name = Infraestructure.Domain.Entities.OpenApi.OpenApiLicense.NAME,
                    Url = new Uri(Infraestructure.Domain.Entities.OpenApi.OpenApiLicense.URL)
                }
            };
        }
    }
}