using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace StudentClassManager.Application.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );

        return services;
    }
}
