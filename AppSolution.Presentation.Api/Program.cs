using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;
using System.Reflection;

#region Swagger variables
const string VERSION = "Version";
const string TITLE = "Title";
const string DESCRIPTION = "Description";
const string TERMS_OF_SERVICE = "TermsOfService";

const string CONTACT = "Contact";
const string CONTACT_NAME = "Name";
const string CONTACT_URL = "Url";
const string CONTACT_EMAIL = "Email";

const string LICENSE = "License";
const string LICENSE_NAME = "Name";
const string LICENSE_URL = "Url";

const string ENDPOINT = "EndPoint";
const string ENDPOINT_NAME = "Name";
const string ENDPOINT_URL = "Url";
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(conf =>
{
    conf.SwaggerDoc(SwaggerConfigSection(builder, VERSION), new OpenApiInfo
    {
        Version = SwaggerConfigSection(builder, VERSION),
        Title = SwaggerConfigSection(builder, TITLE),
        Description = SwaggerConfigSection(builder, DESCRIPTION),
        TermsOfService = new Uri(SwaggerConfigSection(builder, TERMS_OF_SERVICE)),
        Contact = new OpenApiContact
        {
            Name = SwaggerConfigSubSection(builder, CONTACT, CONTACT_NAME),
            Email = SwaggerConfigSubSection(builder, CONTACT, CONTACT_EMAIL),
            Url = new Uri(SwaggerConfigSubSection(builder, CONTACT, CONTACT_URL)),
        },
        License = new OpenApiLicense
        {
            Name = SwaggerConfigSubSection(builder, LICENSE, LICENSE_NAME),
            Url = new Uri(SwaggerConfigSubSection(builder, LICENSE, LICENSE_URL)),
        }
    });

    var xmlFilename = SwaggerConfigPathXmlFileName();

    if (File.Exists(xmlFilename))
    {
        conf.IncludeXmlComments(xmlFilename);
    }
    else
    {
        File.Create(xmlFilename).Dispose();
        conf.IncludeXmlComments(xmlFilename);
    }
});

builder.Services.AddControllers(conf => conf.RespectBrowserAcceptHeader = true);

builder.Services.AddCors();

builder.Services.AddMvc().AddMvcOptions(conf => conf.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Code for Development here.
    app.UseSwagger();
    app.UseSwaggerUI(conf => conf.SwaggerEndpoint(SwaggerConfigSubSection(builder, ENDPOINT, ENDPOINT_URL), SwaggerConfigSubSection(builder, ENDPOINT, ENDPOINT_NAME)));

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

app.UseCors(conf => conf.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#region Methods
static string SwaggerConfigSection(WebApplicationBuilder builder, string section) => string.IsNullOrEmpty(section) ? string.Empty : builder.Configuration[$"SwaggerConfiguration:{section}"];

static string SwaggerConfigSubSection(WebApplicationBuilder builder, string section, string subSection) => string.IsNullOrEmpty(section) ? string.Empty : builder.Configuration[$"SwaggerConfiguration:{section}:{subSection}"];

static string SwaggerConfigPathXmlFileName() => Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
#endregion