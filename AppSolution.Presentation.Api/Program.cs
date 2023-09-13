using Microsoft.OpenApi.Models;
using System.Reflection;

#region Swagger variables
const string version = "Version";
const string title = "Title";
const string description = "Description";
const string termsOfService = "TermsOfService";

const string contact = "Contact";
const string contactName = "Name";
const string contactUrl = "Url";
const string contactEmail = "Email";

const string license = "License";
const string licenseName = "Name";
const string licenseUrl = "Url";

const string endPoint = "EndPoint";
const string endPointName = "Name";
const string endPointUrl = "Url";
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(SwaggerConfigSection(builder, version), new OpenApiInfo
    {
        Version = SwaggerConfigSection(builder, version),
        Title = SwaggerConfigSection(builder, title),
        Description = SwaggerConfigSection(builder, description),
        TermsOfService = new Uri(SwaggerConfigSection(builder, termsOfService)),
        Contact = new OpenApiContact
        {
            Name = SwaggerConfigSubSection(builder, contact, contactName),
            Email = SwaggerConfigSubSection(builder, contact, contactEmail),
            Url = new Uri(SwaggerConfigSubSection(builder, contact, contactUrl)),
        },
        License = new OpenApiLicense
        {
            Name = SwaggerConfigSubSection(builder, license, licenseName),
            Url = new Uri(SwaggerConfigSubSection(builder, license, licenseUrl)),
        }
    });

    var xmlFilename = SwaggerConfigPathXmlFilename();

    if (File.Exists(xmlFilename))
    {
        options.IncludeXmlComments(xmlFilename);
    }
    else
    {
        File.Create(xmlFilename).Dispose();
        options.IncludeXmlComments(xmlFilename);
    }
});

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Code for Development here.
    app.UseSwagger();
    app.UseSwaggerUI(s => s.SwaggerEndpoint(SwaggerConfigSubSection(builder, endPoint, endPointUrl), SwaggerConfigSubSection(builder, endPoint, endPointName)));
}
else if (app.Environment.IsStaging())
{
    // Code for Homologation here.
}
else if (app.Environment.IsProduction())
{
    // Code for Production here.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#region Methods
static string SwaggerConfigSection(WebApplicationBuilder builder, string section) => string.IsNullOrEmpty(section) ? string.Empty : builder.Configuration[$"SwaggerConfiguration:{section}"];

static string SwaggerConfigSubSection(WebApplicationBuilder builder, string section, string subSection) => string.IsNullOrEmpty(section) ? string.Empty : builder.Configuration[$"SwaggerConfiguration:{section}:{subSection}"];

static string SwaggerConfigPathXmlFilename() => Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
#endregion