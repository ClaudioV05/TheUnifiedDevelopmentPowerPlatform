using Microsoft.OpenApi.Models;
using System.Reflection;

#region Swagger variables
const string version = "Version";
const string title = "Title";
const string description = "Description";
const string termsOfService = "TermsOfService";

const string contact = "Contact";
const string contactName = "Name";
const string contactEmail = "Email";
const string contactUrl = "Url";

const string license = "License";
const string licenseName = "Name";
const string licenseUrl = "Url";

const string endPoint = "EndPoint";
const string endPointUrl = "Url";
const string endPointName = "Name";
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(SwaggerConfigurationSection(builder, version), new OpenApiInfo
    {
        Version = SwaggerConfigurationSection(builder, version),
        Title = SwaggerConfigurationSection(builder, title),
        Description = SwaggerConfigurationSection(builder, description),
        TermsOfService = new Uri(SwaggerConfigurationSection(builder, termsOfService)),
        Contact = new OpenApiContact
        {
            Name = SwaggerConfigurationSubSection(builder, contact, contactName),
            Email = SwaggerConfigurationSubSection(builder, contact, contactEmail),
            Url = new Uri(SwaggerConfigurationSubSection(builder, contact, contactUrl)),
        },
        License = new OpenApiLicense
        {
            Name = SwaggerConfigurationSubSection(builder, license, licenseName),
            Url = new Uri(SwaggerConfigurationSubSection(builder, license, licenseUrl)),
        }
    });

    var xmlFilename = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

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
    app.UseSwaggerUI(s => s.SwaggerEndpoint(SwaggerConfigurationSubSection(builder, endPoint, endPointUrl), SwaggerConfigurationSubSection(builder, endPoint, endPointName)));
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
static string SwaggerConfigurationSection(WebApplicationBuilder builder, string section) => string.IsNullOrEmpty(section) ? string.Empty : builder.Configuration[$"SwaggerConfiguration:{section}"];

static string SwaggerConfigurationSubSection(WebApplicationBuilder builder, string section, string subSection) => string.IsNullOrEmpty(section) ? string.Empty : builder.Configuration[$"SwaggerConfiguration:{section}:{subSection}"];
#endregion