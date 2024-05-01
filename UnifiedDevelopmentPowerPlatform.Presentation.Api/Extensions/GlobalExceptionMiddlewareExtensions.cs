using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.WebConfiguration;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Models;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions;

public static class UnifiedDevelopmentPowerPlatformExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = WebConfiguration.ContentTypeApplicationJson;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature is not null)
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