using System.Threading.Tasks;
using AspNetCore_Portfolio.Middlewares;
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
            services.AddTransient<SimpleMiddleware>();
            // services.AddTransient<CustomMiddleware>(); -- Only IMiddleware
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMiddleware<SimpleMiddleware>();
            app.UseCustomMiddleware();

            app.Run(async (context) =>
            {
                z = x * y;
                // await next.Invoke();
            });

            app.UseEndpoints(endpoints => { endpoints.MapGet("/", Home); });

            app.Run(async (context) => { await context.Response.WriteAsync($"Результат x * y = {z}"); });
        }

        private async Task Home(HttpContext context)
        {
            x++;
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"User: {x.ToString("#,#")} , z = {z}");
        }
    }
}