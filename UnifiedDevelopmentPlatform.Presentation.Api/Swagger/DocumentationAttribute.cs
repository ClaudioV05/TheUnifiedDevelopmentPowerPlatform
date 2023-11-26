using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Swagger
{
    public class DocumentationAttribute : IDocumentFilter
    {
        /// <summary>
        /// Documentation about Information of API.
        /// </summary>
        private record DocumentationInfo
        {
            public const string VERSION = "v1";
            public const string TITLE = "UNIFIED DEVELOPMENT PLATFORM";
            public const string DESCRIPTION = "Generator of Class C#";
            public const string TERMSOFSERVICE = "https://claudiomildo.net/terms";
        }

        /// <summary>
        /// Documentation about Contact of API.
        /// </summary>
        private record DocumentationContact
        {
            public const string NAME = "CLAUDIOMILDO VENTURA";
            public const string EMAIL = "claudiomildo@hotmail.com";
            public const string URL = "https://www.claudiomildo.net";
        }

        /// <summary>
        /// Documentation about License of API.
        /// </summary>
        private record DocumentatioLicense
        {
            public const string NAME = "Information about the license.";
            public const string URL = "https://claudiomildo.net/license";
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Info = new OpenApiInfo
            {
                Version = DocumentationInfo.VERSION,
                Title = DocumentationInfo.TITLE,
                Description = DocumentationInfo.DESCRIPTION,
                TermsOfService = new Uri(DocumentationInfo.TERMSOFSERVICE),
                Contact = new OpenApiContact
                {
                    Name = DocumentationContact.NAME,
                    Email = DocumentationContact.EMAIL,
                    Url = new Uri(DocumentationContact.URL)
                },
                License = new OpenApiLicense
                {
                    Name = DocumentatioLicense.NAME,
                    Url = new Uri(DocumentatioLicense.URL)
                }
            };
        }
    }
}