using System;
using System.Net.Http.Headers;
using FCity.Currency.Service.Business.Service.Http;
using FCity.Currency.Service.Business.Service.Http.Interface;
using FCity.Currency.Service.Models.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FCity.Currency.Service.Api.Infrastructure.ConfigureServices
{
    public static class HttpClients
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var generalSettings = new GeneralSettingsModel();
            configuration.GetSection("GeneralSettings").Bind(generalSettings);

            services.AddHttpClient<ICurrencyHttpService, CurrencyHttpService>(client =>
            {
                client.BaseAddress = new Uri(generalSettings.CurrencyApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            return services;

        }


    }
}