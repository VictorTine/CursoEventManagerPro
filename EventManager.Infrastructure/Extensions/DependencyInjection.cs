using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using EventManager.Application.Interfaces;
using EventManager.Infrastructure.Repositories;

namespace EventManager.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Registrar o DbContext
        services.AddDbContext<EventManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Repositórios
        services.AddScoped<IEventRepository, EventRepository>();

        return services;
    }
}
