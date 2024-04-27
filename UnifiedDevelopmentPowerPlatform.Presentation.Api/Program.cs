using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Application.Services;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.OpenApi;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Filters;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.OpenApi;

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
    //options.RespectBrowserAcceptHeader = true;
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
builder.Services.TryAddTransient<FilterActionContextMetadata<MetadataOwner>>();
builder.Services.TryAddTransient<FilterActionContextTablesdata<MetadataOwner>>();
#endregion Action Filters.

#region Services.
builder.Services.TryAddScoped<IServiceArchitecturePatterns, ServiceArchitecturePatterns>();
builder.Services.TryAddScoped<IServiceCrypto, ServiceCrypto>();
builder.Services.TryAddScoped<IServiceDatabaseEngine, ServiceDatabaseEngine>();
builder.Services.TryAddScoped<IServiceDatabases, ServiceDatabases>();
builder.Services.TryAddScoped<IServiceDataTypeAnsiSql, ServiceDataTypeAnsiSql>();
builder.Services.TryAddScoped<IServiceDataTypeCSharp, ServiceDataTypeCSharp>();
builder.Services.TryAddScoped<IServiceDataTypeSqlServer, ServiceDataTypeSqlServer>();
builder.Services.TryAddScoped<IServiceDate, ServiceDate>();
builder.Services.TryAddScoped<IServiceDevelopmentEnvironments, ServiceDevelopmentEnvironments>();
builder.Services.TryAddScoped<IServiceDirectory, ServiceDirectory>();
builder.Services.TryAddScoped<IServiceEnumerated, ServiceEnumerated>();
builder.Services.TryAddScoped<IServiceFile, ServiceFile>();
builder.Services.TryAddScoped<IServiceFormsView, ServiceFormsView>();
builder.Services.TryAddScoped<IServiceFuncString, ServiceFuncString>();
builder.Services.TryAddScoped<IServiceGuid, ServiceGuid>();
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
builder.Services.TryAddScoped<IServiceZipFile, ServiceZipFile>();
#endregion Services.

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Code for Development here.

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
app.Run();