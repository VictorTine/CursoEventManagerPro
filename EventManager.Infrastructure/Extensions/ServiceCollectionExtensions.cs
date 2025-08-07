using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EventManager.Application.Interfaces;
using EventManager.Infrastructure.Persistence;
using EventManager.Infrastructure.Repositories;

namespace EventManager.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<EventManagerDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
