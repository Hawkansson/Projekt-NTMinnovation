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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Nyhetssajt.Models;
using Nyhetssajt.Data;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Hosting;

namespace Nyhetssajt
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
            //MvcOptions.EnableEndpointRouting = false;
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            

            services.AddDbContext<NyhetspuffsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("NyhetspuffsContext")));

            services.AddCors(options =>
            {
              options.AddPolicy("CorsPolicy",
              builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                //.AllowCredentials()
                );
            });

            services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));

            services.AddSpaStaticFiles(Configuration =>
            {
              Configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
              app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
              routes.MapRoute(
                name: "default",
                template: "{controller}/{action=Index}/{id?}");
            });


            app.UseSpa(spa =>
            {
              spa.Options.SourcePath = "ClientApp";

              if (env.IsDevelopment())
              {
                spa.UseAngularCliServer(npmScript: "start");
              }
            });
        }
    }
}
