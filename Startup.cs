using System;
using System.Threading.Tasks;
using AspNetCore_Portfolio.Constants;
using AspNetCore_Portfolio.Middlewares;
using AspNetCore_Portfolio.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCore_Portfolio
{
    public class Startup
    {
        int x = 5;
        int y = 8;
        int z = 0;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("us.example.com");
                options.ExcludedHosts.Add("www.example.com");
            });
            services.AddTransient<ITestService, TestService>(); //Dependency injection
            services.AddTransient<SimpleMiddleware>();
            // services.AddTransient<CustomMiddleware>(); -- Only IMiddleware
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ITestService testService)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseExceptionHandler();//For client exception processing
            }
            
            app.UseRouting();
            app.UseHsts(); //Strict-Transport-Security
            app.UseMiddleware<SimpleMiddleware>();
            app.UseCustomMiddleware();

            app.Run(async (context) =>
            {
                context.Response.WriteAsync(testService.Send());
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", Home);
                endpoints.MapGet(Endpoints.Error, OnError);
            });

            app.Run(async (context) => { await context.Response.WriteAsync($"Результат x * y = {z}"); });
        }

        private async Task OnError(HttpContext context)
        {
            context.Response.StatusCode = 400;
        }

        private async Task Home(HttpContext context)
        {
            x++;
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"User: {x.ToString("#,#")} , z = {z}");
        }
    }
}