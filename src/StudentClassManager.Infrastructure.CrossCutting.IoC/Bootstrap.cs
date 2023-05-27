using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentClassManager.Application.Extensions;
using StudentClassManager.Infrastructure.Persistence.Extensions;

namespace StudentClassManager.Infrastructure.CrossCutting.IoC;

public static class Bootstrap
{
    public static void AddApi(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddApplicationService();
        service.AddPersistence(configuration);
    }
}
