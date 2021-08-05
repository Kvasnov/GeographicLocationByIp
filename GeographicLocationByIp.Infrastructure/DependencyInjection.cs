using GeographicLocationByIp.Application.Common.Interfaces.Repositories;
using GeographicLocationByIp.Infrastructure.Repositories;
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
            services.AddDbContext<DatabaseContext.DatabaseContext>(options => options.UseNpgsql(defaultDatabaseConnection, b => b.MigrationsAssembly(typeof( DatabaseContext.DatabaseContext ).Assembly.FullName)));
            services.AddTransient<IGeographicLocationRepository, GeographicLocationRepository>();

            return services;
        }
    }
}