using Microsoft.AspNetCore.Mvc.Formatters;
using System.Reflection;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Application.Services;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.OpenApi;
using UnifiedDevelopmentPlatform.Presentation.Api.Extensions;
using UnifiedDevelopmentPlatform.Presentation.Api.Filters;
using UnifiedDevelopmentPlatform.Presentation.Api.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(options =>
{
    options.DocumentFilter<DocumentationAttribute>();
    options.OperationFilter<DocumentationHeaderAttribute>();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
    else
    {
        File.Create(xmlPath).Dispose();
        options.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddControllers(options => options.RespectBrowserAcceptHeader = true);

builder.Services.AddCors();

builder.Services.AddMvc().AddMvcOptions(options => options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

#region Action Filters.

builder.Services.AddScoped<FilterActionContextController>();
builder.Services.AddScoped<FilterActionContextLog>();
builder.Services.AddScoped<FilterActionContextFields<Metadata>>();
builder.Services.AddScoped<FilterActionContextTables<Metadata>>();

#endregion Action Filters.

#region Dependency Injection.

#region Services.
builder.Services.AddScoped<IServiceAppSettings, ServiceAppSettings>();
builder.Services.AddScoped<IServiceCrypto, ServiceCrypto>();
builder.Services.AddScoped<IServiceDirectory, ServiceDirectory>();
builder.Services.AddScoped<IServiceEmail, ServiceEmail>();
builder.Services.AddScoped<IServiceEnvironment, ServiceEnvironment>();
builder.Services.AddScoped<IServiceXml, ServiceXml>();
builder.Services.AddScoped<IServiceFile, ServiceFile>();
builder.Services.AddScoped<IServiceFuncStrings, ServiceFuncStrings>();
builder.Services.AddScoped<IServiceJson, ServiceJson>();
builder.Services.AddScoped<IServiceLinq, ServiceLinq>();
builder.Services.AddScoped<IServiceLog, ServiceLog>();
builder.Services.AddScoped<IServiceMetadata, ServiceMetadata>();
builder.Services.AddScoped<IServiceMetadataFields, ServiceMetadataFields>();
builder.Services.AddScoped<IServiceMetadataTables, ServiceMetadataTables>();
builder.Services.AddScoped<IServiceValidation, ServiceValidation>();
builder.Services.AddScoped<IServiceZipFile, ServiceZipFile>();
builder.Services.AddScoped<IServiceOperationalSystem, ServiceOperationalSystem>();
builder.Services.AddScoped<IServiceDate, ServiceDate>();

#endregion Services.

#region Repositories.
// Code from Repositories here.
#endregion Repositories.

#endregion Dependency Injection.

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Code for Development here.
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(OpenApiConfiguration.ENDPOINT, OpenApiInformation.DESCRIPTION);
        options.InjectStylesheet(OpenApiConfiguration.STYLE_SHEET);
    });

    app.UseDeveloperExceptionPage();
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

app.Use(async (context, next) =>
{
    context.Response.OnStarting((state) =>
    {
        context.Response.Headers.Add("x-unifieddevelopmentplatform", "UnifiedDevelopmentPlatform");

        if (context.Response.Headers.Count > 0 && context.Response.Headers.ContainsKey("Content-Type"))
        {
            var contentType = context.Response.Headers["Content-Type"].ToString();

            if (contentType.StartsWith("application/json"))
            {
                context.Response.Headers.Remove("Content-Type");
                context.Response.Headers.Append("Content-Type", "application/json");
            }
        }

        return Task.FromResult(0);
    },context);

    await next.Invoke();

});

app.Run();