using FCity.Currency.Service.Models.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FCity.Currency.Service.Api.Infrastructure.ConfigureServices
{
    public static class Settings
    {
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<ConnectionStringsModel>(configuration.GetSection("ConnectionStrings"));
        }
    }
}
