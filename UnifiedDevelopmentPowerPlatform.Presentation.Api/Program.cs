using Microsoft.Extensions.DependencyInjection.Extensions;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.OpenApi;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Method registers endpoint explorers to the DI container.
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers(c => c.Conventions.Add(new OpenApiHideControllerConvention()));

builder.Services.ConfigureMvc();

builder.Services.ConfigureCors();

builder.Services.ConfigureSwagger();

builder.Services.ConfigureDependencies();

builder.Services.ConfigureDependencies(nameof(UnifiedDevelopmentPowerPlatform));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Code for Development here.
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(OpenApiConfiguration.Endpoint, OpenApiInformation.Description);
        options.InjectStylesheet(OpenApiConfiguration.StyleSheet);
        options.EnableTryItOutByDefault();
    });

    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/UnifiedDevelopmentPowerPlatform")
        {
            context.Response.Redirect(OpenApiConfiguration.Html);
            return;
        }

        await next();
    });
}
else if (app.Environment.IsStaging())
{
    // Code for Homologation here.
}
else if (app.Environment.IsProduction())
{
    // Code for Production here.

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();