using CleanArchitecture.WebAPI.Configurations;
using CleanArchitecture.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.
    InstallService(builder.Configuration, builder.Host, typeof(IServiceInstaller).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.useMiddlewareExtensions();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
