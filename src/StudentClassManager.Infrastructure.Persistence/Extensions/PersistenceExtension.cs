using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using UoW = StudentClassManager.Infrastructure.Persistence.UnitOfWork;
using StudentClassManager.Infrastructure.Persistence.DapperConfigurations.TypeMappers;
using StudentClassManager.Infrastructure.Persistence.Repositories;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Infrastructure.Persistence.Extensions;

public static class PersistenceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // Connection / Dapper
        services.AddScoped<UoW.IUnitOfWork, UoW.UnitOfWork>(service =>
        {
            var connectionString = configuration.GetSection("Database:ConnectionString")?.Value;
            return new UoW.UnitOfWork(connectionString!);
        });

        TypeMapper.Initialize();

        // Repositories
        services.AddScoped<IStudentRepository, StudentRepository>();

        return services;
    }
}