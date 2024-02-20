using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Application.Services;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.OpenApi;
using UnifiedDevelopmentPlatform.Presentation.Api.Extensions;
using UnifiedDevelopmentPlatform.Presentation.Api.Filters;
using UnifiedDevelopmentPlatform.Presentation.Api.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Method registers endpoint explorers to the DI container.
builder.Services.AddEndpointsApiExplorer();

#region OpenApi.
builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<OpenApiIgnoreFilter>();
    options.DocumentFilter<OpenApiDocumentation>();
    options.OperationFilter<OpenApiParameters>();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}{FileExtension.Xml}";
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
#endregion OpenApi.

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.Conventions.Add(new OpenApiHideControllerConvention());
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddMvc().AddMvcOptions(options => options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

#region Action Filters.
builder.Services.TryAddTransient<FilterActionContextController>();
builder.Services.TryAddTransient<FilterActionContextControllerInformation>();
builder.Services.TryAddTransient<FilterActionContextLog>();
builder.Services.TryAddTransient<FilterActionContextFields<MetadataOwner>>();
builder.Services.TryAddTransient<FilterActionContextTables<MetadataOwner>>();
#endregion Action Filters.

#region Dependency Injection.

#region Services.
builder.Services.TryAddScoped<IServiceAppSettings, ServiceAppSettings>();
builder.Services.TryAddScoped<IServiceArchitecturePatterns, ServiceArchitecturePatterns>();
builder.Services.TryAddScoped<IServiceCrypto, ServiceCrypto>();
builder.Services.TryAddScoped<IServiceCsv, ServiceCsv>();
builder.Services.TryAddScoped<IServiceDatabase, ServiceDatabase>();
builder.Services.TryAddScoped<IServiceDatabaseEngine, ServiceDatabaseEngine>();
builder.Services.TryAddScoped<IServiceDate, ServiceDate>();
builder.Services.TryAddScoped<IServiceDevelopmentEnvironment, ServiceDevelopmentEnvironment>();
builder.Services.TryAddScoped<IServiceDirectory, ServiceDirectory>();
builder.Services.TryAddScoped<IServiceEnumerated, ServiceEnumerated>();
builder.Services.TryAddScoped<IServiceFile, ServiceFile>();
builder.Services.TryAddScoped<IServiceForm, ServiceForm>();
builder.Services.TryAddScoped<IServiceFuncString, ServiceFuncString>();
builder.Services.TryAddScoped<IServiceJson, ServiceJson>();
builder.Services.TryAddScoped<IServiceLinq, ServiceLinq>();
builder.Services.TryAddScoped<IServiceLog, ServiceLog>();
builder.Services.TryAddScoped<IServiceMail, ServiceMail>();
builder.Services.TryAddScoped<IServiceMessage, ServiceMessage>();
builder.Services.TryAddScoped<IServiceMetadata, ServiceMetadata>();
builder.Services.TryAddScoped<IServiceMetadataField, ServiceMetadataField>();
builder.Services.TryAddScoped<IServiceMetadataTable, ServiceMetadataTable>();
builder.Services.TryAddScoped<IServicePlataform, ServicePlataform>();
builder.Services.TryAddScoped<IServiceValidation, ServiceValidation>();
builder.Services.TryAddScoped<IServiceXml, ServiceXml>();
builder.Services.TryAddScoped<IServiceZipFile, ServiceZipFile>();
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

    #region Swagger.
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(OpenApiConfiguration.Endpoint, OpenApiInformation.Description);
        options.InjectStylesheet(OpenApiConfiguration.StyleSheet);
        options.EnableTryItOutByDefault();
    });
    #endregion Swagger.

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
    }, context);

    await next.Invoke();

});

app.Run();