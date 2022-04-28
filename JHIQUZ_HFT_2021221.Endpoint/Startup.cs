using JHIQUZ_HFT_2021221.Data;
using JHIQUZ_HFT_2021221.Endpoint.Services;
using JHIQUZ_HFT_2021221.Logic;
using JHIQUZ_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //car services
            services.AddTransient<ICarLogic,CarLogic>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<CarShopContext, CarShopContext>();
            //engine services
            services.AddTransient<IEngineLogic, EngineLogic>();
            services.AddTransient<IEngineRepository, EngineRepository>();
            services.AddTransient<CarShopContext, CarShopContext>();
            //brand services
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<CarShopContext, CarShopContext>();
            //
            services.AddSignalR();
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
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //hogy controllereket használjon
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
