using System.Reflection;
using FluentValidation;
using GeographicLocationByIp.Application.MaxMindGeoLite;
using GeographicLocationByIp.Application.MaxMindGeoLite.Interfaces;
using GeographicLocationByIp.Application.MaxMindGeoLite.Settings;
using GeographicLocationByIp.Application.Mediators.Behaviours;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeographicLocationByIp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGeoLiteClient, GeoLiteClient>();
            services.AddTransient<GeoLiteClientSettings>();
            services.Configure<GeoLiteClientSettings>(configuration.GetSection("GeoLiteClientSettings"));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof( IPipelineBehavior<,> ), typeof( ValidationBehavior<,> ));
            services.AddTransient(typeof( IPipelineBehavior<,> ), typeof( UnhandledExceptionBehaviour<,> ));

            return services;
        }
    }
}