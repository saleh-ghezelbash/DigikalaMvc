using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digikala.Core.Interfaces;
using Digikala.Core.Services;
using Digikala.DataLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Digikala
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
            //services.AddRazorPages();
            services.AddMvc();
          
                 services.AddDbContext<DigikalaContext>(options =>
                 {
                     options.UseSqlServer(Configuration.GetConnectionString("Default"));
                 });

            services.AddTransient<ISliderService, SliderService>();
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
                app.UseExceptionHandler("/Error");
            }

            //app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});

            app.UseStatusCodePagesWithReExecute("/error/PageNotFound");

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defualt", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "user",
                    pattern: "{controller}/{action}/",
                    defaults: new { area = "User", controller = "Profile", action = "index" });

            });

        }
    }
}
