using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddFlightsContext(
        this IServiceCollection services,
        string connectionString,
        string migrationsAssemblyName)
    {
        return services.AddDbContext<FlightsContext>(options =>
        {
            options.UseNpgsql(connectionString,
                npgsqlOptions => { npgsqlOptions.MigrationsAssembly(migrationsAssemblyName); });
        });
    }
}