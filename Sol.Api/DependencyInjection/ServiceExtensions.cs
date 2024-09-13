using Sol.Api.Services;
using Sol.Api.Services.Students;

namespace Sol.Api.DependencyInjection;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        return services;
    }
}