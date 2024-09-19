
using Asp.Versioning.ApiExplorer;
using BuildingBlocks.Exceptions;
using Microsoft.Extensions.Hosting;
using ProductService.Api;
using ProductService.Api.Extensions;
using ProductService.Application;
using ProductService.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
var app = builder.Build();
app.UseExceptionHandler(options => { });
ILogger logger = app.Logger;
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            options.RoutePrefix = "";
        }
    });
    try
    {

        await app.InitialiseDatabaseAsync();
    }
    catch(Exception ex)
    {
        logger.LogError($"Database initialization failed {ex.ToString()}");
    }
    
}
app.UseRouting();

app.MapControllers();

app.Run();

