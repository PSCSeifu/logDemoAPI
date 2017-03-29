using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.AspNetCore.Http;

namespace ms.logDemoAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            InitLogging();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.          
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();
            AddBusiness(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Unexpected Error");
                    });
                });
            }

            //Logging
            loggerFactory.AddConsole();
            loggerFactory.AddSerilog();
            loggerFactory.AddDebug();


            app.UseMvc();
        }

        #region Private

        private static void InitLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("LogDemoAPI","FetchContacts")
                            .MinimumLevel.Verbose()                            
                            .WriteTo.Seq("http://localhost:5341/")
                            .CreateLogger();
        }

        private void AddBusiness(IServiceCollection services) =>  DependencyInjection.Configure(services);
        
        #endregion
    }
}
