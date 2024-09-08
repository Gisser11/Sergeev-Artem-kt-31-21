using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using Sol.Api.DependencyInjection;
using Sol.Api.MiddleWares;
using Sol.Domain;

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=mydatabase;\n"));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddServices();

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();
    app.UseMiddleware<ExceptionHandlerMiddleware>();
    app.MapControllers();

    app.Run();
    app.UseCors();
}
catch (Exception e)
{
    logger.Error(e, "Stopped program!");
    throw;
}
finally
{
    LogManager.Shutdown();
}