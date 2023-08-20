using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebDAL;

namespace WebClient
{
    public class Startup
    {
        private int x = 0;
        
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { 
                endpoints.MapGet("/", async context =>
                {
                    var user = new Guest();
                    x++;
                    await context.Response.WriteAsync($"Hello World! {x}"); 
                }); 
            });
        }
    }
}