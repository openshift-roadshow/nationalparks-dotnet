using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using NationalParks.Models;
using NationalParks.Services;

namespace NationalParks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
                // requires using Microsoft.Extensions.Options
            services.Configure<NationalparksDatabaseSettings>(settings =>
            {
                Configuration.GetSection(nameof(NationalparksDatabaseSettings)).Bind(settings);
                ApplyMongoEnvironment(settings);
            });

            services.AddSingleton<INationalparksDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<NationalparksDatabaseSettings>>().Value);
            
            services.AddSingleton<ParkService>();

            services.AddControllers();
        }

        // The other National Parks backends are wired to MongoDB with the MONGODB_*
        // variables the workshop documents. Honour the same ones here so a single set
        // of Deployment environment variables works for every language.
        private static void ApplyMongoEnvironment(NationalparksDatabaseSettings settings)
        {
            var host = Environment.GetEnvironmentVariable("MONGODB_SERVER_HOST");

            if (string.IsNullOrEmpty(host))
            {
                return;
            }

            var port = Environment.GetEnvironmentVariable("MONGODB_SERVER_PORT");
            var database = Environment.GetEnvironmentVariable("MONGODB_DATABASE");
            var user = Environment.GetEnvironmentVariable("MONGODB_USER");
            var password = Environment.GetEnvironmentVariable("MONGODB_PASSWORD");

            if (!string.IsNullOrEmpty(database))
            {
                settings.DatabaseName = database;
            }

            if (!string.IsNullOrEmpty(user))
            {
                settings.DatabaseUser = user;
            }

            if (!string.IsNullOrEmpty(password))
            {
                settings.DatabasePass = password;
            }

            var credentials = string.IsNullOrEmpty(settings.DatabaseUser)
                ? string.Empty
                : string.Format("{0}:{1}@",
                    Uri.EscapeDataString(settings.DatabaseUser),
                    Uri.EscapeDataString(settings.DatabasePass ?? string.Empty));

            settings.ConnectionString = string.Format("mongodb://{0}{1}:{2}/{3}",
                credentials, host, string.IsNullOrEmpty(port) ? "27017" : port, settings.DatabaseName);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
