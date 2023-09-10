using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AppSolution",
        Description = "Generator of Class C#",
        TermsOfService = new Uri("https://claudiomildo.net/terms"),
        Contact = new OpenApiContact
        {
            Name = "Claudiomildo",
            Email = "claudiomildo@hotmail.com",
            Url = new Uri("https://www.claudiomildo.net"),
        },
        License = new OpenApiLicense
        {
            Name = "Informações sobre a licença.",
            Url = new Uri("https://claudiomildo.net/license"),
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

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Code for Development here.

    app.UseSwagger();
    app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerador de classes MVC"));
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