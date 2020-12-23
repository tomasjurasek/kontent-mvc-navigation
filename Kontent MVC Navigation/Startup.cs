using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Extensions;
using KenticoKontentModels;
using Kontent_MVC_Navigation.Infrastructure;
using Kentico.AspNetCore.LocalizedRouting.Extensions;

namespace Kontent_MVC_Navigation
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
            // Enable configuration services
            services.AddOptions();

            // Kontent services
            services.AddSingleton<ITypeProvider, CustomTypeProvider>()
                    .AddDeliveryClient(Configuration);

            // Localization
            services.AddLocalization();
            services.ConfigureRequestLocalization("en-US", "es-ES");
            services.AddSingleton<CustomLocalizedRoutingTranslationTransformer>();
            services.AddControllersWithViews();
            services.AddLocalizedRouting();


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute($"/Errors/NotFound");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDynamicControllerRoute<CustomLocalizedRoutingTranslationTransformer>("{culture=en-US}/{controller=Home}/{action=Index}/{url_pattern?}");
                endpoints.MapControllerRoute("default", "{culture=en-US}/{controller=Home}/{action=Index}/{url_pattern?}");
            });
        }
    }
}
