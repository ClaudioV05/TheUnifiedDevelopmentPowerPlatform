using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
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

builder.Services.AddClassesMatchingInterfaces(nameof(UnifiedDevelopmentPowerPlatform));

var app = builder.Build();

// Configure the HTTP request pipeline.

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