using UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions.ApplicationBuilder;
using UnifiedDevelopmentPowerPlatform.Presentation.Api.Extensions.ServiceCollection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServiceSolution();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Code for Development here.
    app.UseDeveloperExceptionPage();
    app.ConfigureSwagger();
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