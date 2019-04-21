using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCity.Currency.Service.Models.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using FCity.Currency.Service.Business.Service;
using Microsoft.Extensions.Configuration;
using FCity.Currency.Service.Api.Infrastructure.ConfigureServices;

namespace FCity.Currency.Service.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
      {
          // This lambda determines whether user consent for non-essential cookies is needed for a given request.
          options.CheckConsentNeeded = context => true;
          options.MinimumSameSitePolicy = SameSiteMode.None;
      });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = @"Server=E1-N019\MYDB;Database=FCity_Dev;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddEfSqlServer(Configuration);
            services.AddHttpClients(Configuration);
            // services.AddDbContext<CurrencyContex>
            //     (options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IMinuteCurrencyService, MinuteCurrencyService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
