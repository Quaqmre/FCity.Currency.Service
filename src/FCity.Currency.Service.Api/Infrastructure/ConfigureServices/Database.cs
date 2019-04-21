using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FCity.Currency.Service.Models.Models;



namespace FCity.Currency.Service.Api.Infrastructure.ConfigureServices
{
    public static class Database
    {
        public static IServiceCollection AddEfSqlServer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddEntityFrameworkSqlServer()
            .AddDbContextPool<CurrencyContex>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(30);
                })
                .UseInternalServiceProvider(serviceProvider)
                .EnableSensitiveDataLogging(true)
                .ConfigureWarnings(warnings => warnings.Throw(Microsoft.EntityFrameworkCore.Diagnostics.CoreEventId.IncludeIgnoredWarning));
            }, poolSize: 128);

            return services;
        }

    }
}