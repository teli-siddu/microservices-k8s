using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var hostingEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

// Add Ocelot configuration
builder.Configuration.AddJsonFile($"ocelot.{hostingEnv}.json", optional: false, reloadOnChange: true);

// Add Ocelot services
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();
app.UseOcelot().Wait();
app.Run();
