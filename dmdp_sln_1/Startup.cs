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
using dmdp.Services.Factory;
using dmdp.Services.Interface;
using dmdp.Services.Impl;
using dmdp.common;

namespace dmdp_sln_1
{
    public class Startup
    {
        private ILogger<Startup> _logger;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IBaseLogger, Log4netLogger>();
            services.AddScoped<ErrorHandlingFilter>();
            services.AddSingleton<OfficeApplicationFactory>();
            services.AddSingleton<IOfficeApplication, Word>();
            services.AddSingleton<IOfficeApplication, Excel>();
            services.AddSingleton<IOfficeApplication, Powerpoint>();
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, ILoggerFactory loggerFactory, IBaseLogger requestLogger)
        {
            _logger = logger;
            try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();
                app.UseRouting();
                //app.UseMiddleware<RequestResponseLoggingMiddleware>(requestLogger);
                //app.UseMiddleware<EnableRewindableBodyStartup>();
                // app.UseMiddleware<RateLimitHandler>(requestLogger);
                loggerFactory.AddLog4Net();
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                //Log to application start
                _logger.LogInformation("application started.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"application not started.");
            }
           
            
        }
    }
}
