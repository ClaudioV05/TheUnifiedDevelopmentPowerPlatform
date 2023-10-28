using AppSolution.Infraestructure.Application.Interfaces;
using AppSolution.Infraestructure.Application.Services;
using AppSolution.Infraestructure.Domain.Entities;
using AppSolution.Presentation.Api.Extensions;
using AppSolution.Presentation.Api.Filters;
using AppSolution.Presentation.Api.Swagger;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Reflection;

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
builder.Services.AddScoped<AppSolutionControllerFilter>();
builder.Services.AddScoped<LogRegisterFilter>();
builder.Services.AddScoped<ValidateEntityMetadataFieldsFilter<Metadata>>();
builder.Services.AddScoped<ValidateEntityMetadataTablesFilter<Metadata>>();
#endregion Action Filters.

#region Dependency Injection.
#region Services.
builder.Services.AddScoped<IServiceAppSettings, ServiceAppSettings>();
builder.Services.AddScoped<IServiceCrypto, ServiceCrypto>();
builder.Services.AddScoped<IServiceDirectory, ServiceDirectory>();
builder.Services.AddScoped<IServiceEmail, ServiceEmail>();
builder.Services.AddScoped<IServiceEnvironment, ServiceEnvironment>();
builder.Services.AddScoped<IServiceFile, ServiceFile>();
builder.Services.AddScoped<IServiceFuncStrings, ServiceFuncStrings>();
builder.Services.AddScoped<IServiceJson, ServiceJson>();
builder.Services.AddScoped<IServiceLog, ServiceLog>();
builder.Services.AddScoped<IServiceMetadata, ServiceMetadata>();
builder.Services.AddScoped<IServiceMetadataFields, ServiceMetadataFields>();
builder.Services.AddScoped<IServiceMetadataTables, ServiceMetadataTables>();
builder.Services.AddScoped<IServiceValidation, ServiceValidation>();
builder.Services.AddScoped<IServiceZipFile, ServiceZipFile>();
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
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Generator of Class C#");
        options.InjectStylesheet("/swagger-ui/custom.css");
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
    }, null);
    await next.Invoke();
});

app.Run();