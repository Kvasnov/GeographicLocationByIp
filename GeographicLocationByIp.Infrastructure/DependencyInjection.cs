using GeographicLocationByIp.Application.Common.Interfaces.Repositories;
using GeographicLocationByIp.ConsoleUpdater.Services;
using GeographicLocationByIp.Infrastructure.Repositories;
using GeographicLocationByIp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeographicLocationByIp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultDatabaseConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext.DatabaseContext>(options => options.UseNpgsql(defaultDatabaseConnection));
            services.AddTransient<IGeographicLocationRepository, GeographicLocationRepository>();
            services.AddTransient<IUpdateService, UpdateService>();

            return services;
        }
    }
}