using FictionFactoryExample2.Data;
using FictionFactoryExample2.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FictionFactoryExample2.Services;

namespace FictionFactoryExample2
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
            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<IDrawingstore, DrawingsDBContext>();
            services.Configure<Data.Settings>(
                options =>
                {
                    options.ConnectionString = Configuration.GetSection("MongoDB:ConnectionString").Value;
                    options.Database = Configuration.GetSection("MongoDB:Database").Value;
                });
            services.AddSingleton<DrawingService>();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapPost("/api/drawing", async context =>
        //        {
                    

               
        //        });
        //    });
        }
    }
}
