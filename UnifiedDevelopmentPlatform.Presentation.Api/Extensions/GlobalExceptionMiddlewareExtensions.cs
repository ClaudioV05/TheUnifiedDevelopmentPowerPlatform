using UnifiedDevelopmentPlatform.Presentation.Api.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Extensions
{
    public static class UnifiedDevelopmentPlatformExceptionMiddlewareExtensions
    {
        private const string CONTENT_TYPE = "application/json";
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = CONTENT_TYPE;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                            /*
                             * This two fields take in file of log.
                             * 
                            Source = contextFeature.Error.Source,
                            StackTrace = contextFeature.Error.StackTrace,
                            */
                        }.ToString());
                    }
                });
            });
        }
    }
}